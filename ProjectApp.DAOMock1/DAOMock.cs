using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.DAOMock.DataObjects;
using OleszekMowinski.ProjectApp.Interfaces;
using System.Net.NetworkInformation;

namespace OleszekMowinski.ProjectApp.DAOMock
{
    public class DAOMock : IDAO
    {
        private List<IAirplane> _airplanes;
        private List<IManufacturer> _manufacturers;


        public DAOMock()
        {
            _manufacturers = new List<IManufacturer>()
            {
                new Manufacturer() {Id = Guid.NewGuid(), Name = "Lockheed Martin", Founded = new DateTime(1995,1,1), Headquarters = "Fort Worth", President="James D. Taiclet"},
                new Manufacturer() {Id = Guid.NewGuid(), Name = "Dassault", Founded = new DateTime(1929,1,1), Headquarters = "Paris", President="Eric Trappier"}
            };

            _airplanes = new List<IAirplane>()
            {
                new Airplane()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = _manufacturers[0],
                    Name="F-16 Raptor",
                    Introduction = new DateTime(1978,5,18),
                    Status = AirplaneStatus.InService,
                    Weight = 56533
                },
                new Airplane()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = _manufacturers[0],
                    Name="F-22 Raptor",
                    Introduction = new DateTime(2005,12,15),
                    Status = AirplaneStatus.InService,
                    Weight = 12312
                },
                new Airplane()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = _manufacturers[1],
                    Name="Rafale",
                    Introduction = new DateTime(2001,5,18),
                    Status = AirplaneStatus.InService,
                    Weight = 9979
                },
            };
        }

        public IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            var airplane = new Airplane 
            { 
                Id = Guid.NewGuid(), Name = name, Introduction = introduction, Weight = weight, Status = status, ManufacturerId = manufacturerId, Manufacturer = GetManufacturer(manufacturerId) 
            };
            _airplanes.Add(airplane);
            return airplane;
        }

        public IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president)
        {
            var manufacturer = new Manufacturer
            {
                Id = Guid.NewGuid(),
                Name = name,
                Founded = founded,
                Headquarters = headquaters,
                President = president
            };
            _manufacturers.Add(manufacturer);
            return manufacturer;
        }

        public void DeleteAirplane(Guid id)
        {
            var airplane = _airplanes.FirstOrDefault(x => x.Id == id);
            if(airplane != null)
            {
                _airplanes.Remove(airplane);
            }
        }

        public void DeleteManufacturer(Guid id)
        {
            var manufacturer = _manufacturers.FirstOrDefault(x => x.Id == id);
            if (manufacturer != null)
            {
                _manufacturers.Remove(manufacturer);
            }
        }

        public IEnumerable<IAirplane> GetAirplanes()
        {
            return _airplanes;
        }


        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter)
        {
            var filtered = _airplanes.AsQueryable();

            if (filter.Introduction != null)
            {
                if (filter.BeforeIntroduction)
                {
                    filtered = filtered.Where(a => a.Introduction <= filter.Introduction);
                }
                else
                {
                    filtered = filtered.Where(a => a.Introduction >= filter.Introduction);
                }
            }

            if (filter.Weight != null)
            {
                if (filter.BelowWeight)
                {
                    filtered = filtered.Where(a => a.Weight <= filter.Weight);
                }
                else
                {
                    filtered = filtered.Where(a => a.Weight >= filter.Weight);
                }
            }


            if (filter.Status != null)
            {
                filtered = filtered.Where(a => a.Status == filter.Status);
            }

            if (filter.ManufacturerId != null)
            {
                filtered = filtered.Where(a => a.ManufacturerId == filter.ManufacturerId);
            }

            return filtered;
        }

        public IEnumerable<IManufacturer> GetManufacturers()
        {
            return _manufacturers;
        }

        public IAirplane? GetAirplane(Guid id)
        {
            return _airplanes.FirstOrDefault(a => a.Id == id);
        }

        public IManufacturer? GetManufacturer(Guid id)
        {
            return _manufacturers.FirstOrDefault(x => x.Id == id);   
        }

        public IAirplane? EditAirplane(Guid id, string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            var modifiedAirplane = _airplanes.FirstOrDefault(a => a.Id == id);
            if (modifiedAirplane != null)
            {
                modifiedAirplane.Name = name;
                modifiedAirplane.Introduction = introduction;
                modifiedAirplane.Weight = weight;
                modifiedAirplane.Manufacturer = GetManufacturer(manufacturerId);
                modifiedAirplane.ManufacturerId = manufacturerId;
                modifiedAirplane.Status = status;
                return modifiedAirplane;

            }
            else
            {
                return null;
            }
        }

        public IManufacturer? EditManufacturer(Guid id, string name, DateTime founded, string headquaters, string president)
        {
            var modifiedManufacturer = _manufacturers.FirstOrDefault(a => a.Id == id);
            if (modifiedManufacturer != null)
            {
                modifiedManufacturer.Name = name;
                modifiedManufacturer.Founded = founded;
                modifiedManufacturer.Headquarters = headquaters;
                modifiedManufacturer.President = president;
                return modifiedManufacturer;

            }
            else
            {
                return null;
            }
        }
    }
}
