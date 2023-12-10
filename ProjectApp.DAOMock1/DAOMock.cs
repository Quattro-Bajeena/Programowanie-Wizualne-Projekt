using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.DAOMock1.DataObjects;
using OleszekMowinski.ProjectApp.Interfaces;

namespace OleszekMowinski.ProjectApp.DAOMock1
{
    public class DAOMock : IDAO
    {
        private List<IAirplane> airplanes;
        private List<IManufacturer> manufacturers;


        public DAOMock()
        {
            manufacturers = new List<IManufacturer>()
            {
                new Manufacturer() {Id = Guid.NewGuid(), Name = "Lockheed Martin", Founded = new DateTime(1995,1,1), Headquarters = "Fort Worth", President="James D. Taiclet"},
                new Manufacturer() {Id = Guid.NewGuid(), Name = "Dassault", Founded = new DateTime(1929,1,1), Headquarters = "Paris", President="Eric Trappier"}
            };

            airplanes = new List<IAirplane>()
            {
                new Airplane()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = manufacturers[0],
                    Name="F-22 Raptor",
                    Introduction = new DateTime(1978,5,18),
                    Status = AirplaneStatus.InService,
                    Weight = 56533
                },
                new Airplane()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = manufacturers[0],
                    Name="F-22 Raptor",
                    Introduction = new DateTime(2005,12,15),
                    Status = AirplaneStatus.InService,
                    Weight = 12312
                },
                new Airplane()
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = manufacturers[1],
                    Name="Rafale",
                    Introduction = new DateTime(2001,5,18),
                    Status = AirplaneStatus.InService,
                    Weight = 9979
                },
            };
        }

        public IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId)
        {
            return new Airplane();
        }

        public IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president)
        {
            return new Manufacturer();
        }

        public void DeleteAirplane(Guid id)
        {
            
        }

        public void DeleteManufacturer(Guid id)
        {
            
        }

        public IEnumerable<IAirplane> GetAirplanes()
        {
            return airplanes;
        }


        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter)
        {
            // TODO?
            return airplanes;
        }

        public IEnumerable<IManufacturer> GetManufacturers()
        {
            return manufacturers;
        }

        public IAirplane ModifyAirplane(IAirplane airplane)
        {
            throw new NotImplementedException();
        }

        public IManufacturer ModifyManufacturer(IManufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
