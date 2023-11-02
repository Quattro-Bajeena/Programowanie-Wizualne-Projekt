using ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DAOMock1
{
    public class DAOMock : IDAO
    {

        private List<IProducer> producers;
        private List<ICar> cars;


        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Id = 1, Name = "Toyota"},
                new BO.Producer() {Id = 2, Name = "BMW"}
            };

            cars = new List<ICar>()
            {
                new BO.Car()
                {
                    Id = 1,
                    Producer = producers[0],
                    Name="Rav4",
                    ProductionYear = 2020,
                    Transmission = Core.TransmissionType.Automatic
                },
                new BO.Car()
                {
                    Id = 2,
                    Producer = producers[1],
                    Name="X5",
                    ProductionYear = 2015,
                    Transmission = Core.TransmissionType.Manual
                },
                new BO.Car()
                {
                    Id = 3,
                    Producer = producers[1],
                    Name="Yaris",
                    ProductionYear = 2022,
                    Transmission = Core.TransmissionType.Automatic
                },
            };
        }

        public ICar CreateNewCar()
        {
            return new BO.Car();
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IEnumerable<ICar> GetAllCars()
        {
            return cars;
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return producers;
        }
    }
}
