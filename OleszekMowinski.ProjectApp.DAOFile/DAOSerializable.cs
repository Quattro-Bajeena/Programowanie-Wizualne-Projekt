using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.DAOFile.DataObjects;
using OleszekMowinski.ProjectApp.DAOSQL.DataObjects;
using OleszekMowinski.ProjectApp.Interfaces;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OleszekMowinski.ProjectApp.DAOFile
{
    public class DAOSerializable : IDAO
    {
        private Database _database = new Database();
        private readonly string _databaseFile = "database.json";

        public DAOSerializable()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _databaseFile = Path.Combine(currentPath, "database.json");
            Deserialize();
        }

        private void Deserialize()
        {
            if (File.Exists(_databaseFile))
            {
                var json = File.ReadAllText(_databaseFile);
                _database = JsonSerializer.Deserialize<Database>(json);
            }
            else
            {
                Serialize();
            }
            
        }

        private void Serialize()
        {
            string jsonString = JsonSerializer.Serialize(_database);
            File.WriteAllText(_databaseFile, jsonString);
        }

        public IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            var airplane = new Airplane
            {
                Id = Guid.NewGuid(),
                Name = name,
                Introduction = introduction,
                Weight = weight,
                Status = status,
                ManufacturerId = manufacturerId,
                Manufacturer = GetManufacturer(manufacturerId)
            };
            _database.Airplanes.Add(airplane);
            Serialize();
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
            _database.Manufacturers.Add(manufacturer);
            Serialize();
            return manufacturer;
        }

        public void DeleteAirplane(Guid id)
        {
            var airplane = _database.Airplanes.FirstOrDefault(x => x.Id == id);
            if (airplane != null)
            {
                _database.Airplanes.Remove(airplane);
                Serialize();
            }
        }

        public void DeleteManufacturer(Guid id)
        {
            var manufacturer = _database.Manufacturers.FirstOrDefault(x => x.Id == id);
            if (manufacturer != null)
            {
                _database.Manufacturers.Remove(manufacturer);
                Serialize();
            }
        }

        public IEnumerable<IAirplane> GetAirplanes()
        {
            return _database.Airplanes;
        }


        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter)
        {
            var filtered = _database.Airplanes.AsQueryable();

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
            return _database.Manufacturers;
        }

        public IAirplane? GetAirplane(Guid id)
        {
            var airplane = _database.Airplanes.FirstOrDefault(a => a.Id == id);
            airplane.Manufacturer = GetManufacturer(airplane.ManufacturerId);
            return airplane;
        }

        public IManufacturer? GetManufacturer(Guid id)
        {
            return _database.Manufacturers.FirstOrDefault(x => x.Id == id);
        }

        public IAirplane? EditAirplane(Guid id, string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            var modifiedAirplane = _database.Airplanes.FirstOrDefault(a => a.Id == id);
            if (modifiedAirplane != null)
            {
                modifiedAirplane.Name = name;
                modifiedAirplane.Introduction = introduction;
                modifiedAirplane.Manufacturer = GetManufacturer(manufacturerId);
                modifiedAirplane.ManufacturerId = manufacturerId;
                modifiedAirplane.Status = status;
                Serialize();
                return modifiedAirplane;

            }
            else
            {
                return null;
            }
        }

        public IManufacturer? EditManufacturer(Guid id, string name, DateTime founded, string headquaters, string president)
        {
            var modifiedManufacturer = _database.Manufacturers.FirstOrDefault(a => a.Id == id);
            if (modifiedManufacturer != null)
            {
                modifiedManufacturer.Name = name;
                modifiedManufacturer.Founded = founded;
                modifiedManufacturer.Headquarters = headquaters;
                modifiedManufacturer.President = president;
                Serialize();
                return modifiedManufacturer;
            }
            else
            {
                return null;
            }
        }
    }
}
