﻿using Microsoft.EntityFrameworkCore;
using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.DAOEF.DataObjects;
using OleszekMowinski.ProjectApp.Interfaces;

namespace OleszekMowinski.ProjectApp.DAOEF
{
    public class DAOEntityFramework : IDAO
    {

        private readonly DataContext _dataContext;
        public DAOEntityFramework()
        {
            _dataContext = new DataContext();
        }

        public IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            var id = Guid.NewGuid();
            var newAirplane = new Airplane
            {
                Id = id,
                Name = name,
                Introduction = introduction,
                Weight = weight,
                Status = status,
                ManufacturerIdEF = manufacturerId
            };
            _dataContext.Add(newAirplane);
            _dataContext.SaveChanges();

            return _dataContext.Airplanes.First(a => a.Id == id);

        }

        public IAirplane CreateNewAirplane(IAirplane airplane)
        {
            var airplaneId = Guid.NewGuid();
            airplane.Id = airplaneId;
            _dataContext.Add(airplane);
            _dataContext.SaveChanges();
            return GetAirplane(airplaneId)!;
        }

        public IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president)
        {
            var id = Guid.NewGuid();
            var newManufacturer = new Manufacturer
            {
                Id = id,
                Name = name,
                Founded = founded,
                Headquarters = headquaters,
                President = president
            };
            _dataContext.Add(newManufacturer);
            _dataContext.SaveChanges();
            return _dataContext.Manufacturers.First(a => a.Id == id);

        }

        public IManufacturer CreateNewManufacturer(IManufacturer manufacturer)
        {
            var manufacturerId = Guid.NewGuid();
            manufacturer.Id = manufacturerId;
            _dataContext.Add(manufacturer);
            _dataContext.SaveChanges();
            return GetManufacturer(manufacturerId)!;
        }

        public void DeleteAirplane(Guid id)
        {
            var airplane = _dataContext.Airplanes.FirstOrDefault(a => a.Id == id);
            if (airplane != null)
            {
                _dataContext.Airplanes.Remove(airplane);
                _dataContext.SaveChanges();
            }
        }

        public void DeleteManufacturer(Guid id)
        {
            var manufacturer = _dataContext.Manufacturers.FirstOrDefault(a => a.Id == id);
            if (manufacturer != null)
            {
                _dataContext.Manufacturers.Remove(manufacturer);
                _dataContext.SaveChanges();
            }
        }

        public IAirplane? GetAirplane(Guid id)
        {
            return _dataContext.Airplanes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<IAirplane> GetAirplanes()
        {
            return _dataContext.Airplanes.ToList();
        }

        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter)
        {
            var filtered = _dataContext.Airplanes.AsQueryable();

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
                filtered = filtered.Where(a => a.ManufacturerIdEF == filter.ManufacturerId);
            }

            return filtered.ToList();

        }

        public IManufacturer? GetManufacturer(Guid id)
        {
            return _dataContext.Manufacturers.Include(m => m.Airplanes).FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<IManufacturer> GetManufacturers()
        {
            return _dataContext.Manufacturers.Include(m => m.Airplanes);
        }

        public IAirplane EditAirplane(Guid id, string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            var modifedAirplane = _dataContext.Airplanes.FirstOrDefault(a => a.Id == id);
            if (modifedAirplane != null)
            {
                //modifedAirplane.Manufacturer = airplane.Manufacturer;
                modifedAirplane.ManufacturerIdEF = manufacturerId;
                modifedAirplane.Name = name;
                modifedAirplane.Introduction = introduction;
                modifedAirplane.Status = status;
                modifedAirplane.Weight = weight;
                _dataContext.Update(modifedAirplane);
                _dataContext.SaveChanges();

                return _dataContext.Airplanes.First(a => a.Id == id);
            }
            else
            {
                return new Airplane { Id = id, Name = name, Introduction = introduction, Weight = weight, Status = status, ManufacturerIdEF = manufacturerId };
            }
        }

        public IAirplane EditAirplane(IAirplane airplane)
        {
            var modifedAirplane = _dataContext.Airplanes.FirstOrDefault(a => a.Id == airplane.Id);
            if (modifedAirplane != null)
            {
                //modifedAirplane.Manufacturer = airplane.Manufacturer;
                modifedAirplane.ManufacturerIdEF = airplane.Manufacturer.Id;
                modifedAirplane.Name = airplane.Name;
                modifedAirplane.Introduction = airplane.Introduction;
                modifedAirplane.Status = airplane.Status;
                modifedAirplane.Weight = airplane.Weight;
                _dataContext.Update(modifedAirplane);
                _dataContext.SaveChanges();

                return _dataContext.Airplanes.First(a => a.Id == airplane.Id);
            }
            else
            {
                return airplane;
            }
        }

        public IManufacturer EditManufacturer(Guid id, string name, DateTime founded, string headquaters, string president)
        {
            var modifedManufacturer = _dataContext.Manufacturers.FirstOrDefault(m => m.Id == id);
            if (modifedManufacturer != null)
            {
                modifedManufacturer.Name = name;
                modifedManufacturer.President = president;
                modifedManufacturer.Headquarters = headquaters;
                modifedManufacturer.Founded = founded;
                _dataContext.Update(modifedManufacturer);
                _dataContext.SaveChanges();

                return _dataContext.Manufacturers.Include(m => m.Airplanes).First(a => a.Id == id);
            }
            else
            {
                return new Manufacturer { Id = id, Name = name, Founded = founded, Headquarters = headquaters, President = president };
            }
        }

        public IManufacturer EditManufacturer(IManufacturer manufacturer)
        {
            var modifedManufacturer = _dataContext.Manufacturers.FirstOrDefault(m => m.Id == manufacturer.Id);
            if (modifedManufacturer != null)
            {
                modifedManufacturer.Name = manufacturer.Name;
                modifedManufacturer.President = manufacturer.President;
                modifedManufacturer.Headquarters = manufacturer.Headquarters;
                modifedManufacturer.Founded = manufacturer.Founded;
                _dataContext.Update(modifedManufacturer);
                _dataContext.SaveChanges();

                return _dataContext.Manufacturers.Include(m => m.Airplanes).First(a => a.Id == manufacturer.Id);
            }
            else
            {
                return manufacturer;
            }
        }
    }
}
