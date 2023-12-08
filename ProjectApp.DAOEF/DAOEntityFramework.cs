using Microsoft.EntityFrameworkCore;
using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.DAOEF.DataObjects;
using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.DAOEF
{
    public class DAOEntityFramework : IDAO
    {

        private readonly DataContext _dataContext;
        public DAOEntityFramework() { 
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
                ManufacturerId = manufacturerId
            };
            _dataContext.Add(newAirplane);
            _dataContext.SaveChanges();

            return _dataContext.Airplanes.Include(a => a.ManufacturerEf).First(a => a.Id == id);
            
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

        public IEnumerable<IAirplane> GetAirplanes()
        {
            return _dataContext.Airplanes.Include(a => a.ManufacturerEf).ToList();
        }

        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter)
        {
            var filtered = _dataContext.Airplanes.Include(a => a.ManufacturerEf).AsQueryable();

            if(filter.Introduction != null)
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

            if(filter.Weight != null) 
            { 
                if(filter.BelowWeight)
                {
                    filtered = filtered.Where(a => a.Weight <= filter.Weight);
                }
                else
                {
                    filtered = filtered.Where(a => a.Weight >= filter.Weight);
                }
            }


            if(filter.Status != null)
            {
                filtered = filtered.Where(a => a.Status == filter.Status);
            }

            if(filter.ManufacturerId != null)
            {
                filtered = filtered.Where(a => a.ManufacturerId == filter.ManufacturerId);
            }

            return filtered.ToList();
            
        }

        public IEnumerable<IManufacturer> GetManufacturer()
        {
            return _dataContext.Manufacturers;
        }

        public IAirplane ModifyAirplane(IAirplane airplane)
        {
            var modifedAirplane = _dataContext.Airplanes.FirstOrDefault(a => a.Id == airplane.Id);
            if (modifedAirplane != null)
            {
                modifedAirplane.Manufacturer = airplane.Manufacturer;
                modifedAirplane.ManufacturerId = airplane.Manufacturer.Id;
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

        public IManufacturer ModifyManufacturer(IManufacturer manufacturer)
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

                return _dataContext.Manufacturers.First(a => a.Id == manufacturer.Id);
            }
            else
            {
                return manufacturer;
            }
        }
    }
}
