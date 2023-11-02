using ProjectApp.Interfaces;

namespace ProjectApp.DAOMock2
{
    public class DAOMock : IDAO
    {

        private List<IProducer> producers;
        private List<ICar> cars;


        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Id = 1, Name = "Audi"},
                new BO.Producer() {Id = 2, Name = "Mercedes"}
            };

            cars = new List<ICar>()
            {
                new BO.Car()
                {
                    Id = 1,
                    Producer = producers[0],
                    Name="Aaasda",
                    ProductionYear = 1111,
                    Transmission = Core.TransmissionType.Manual
                },
                new BO.Car()
                {
                    Id = 2,
                    Producer = producers[1],
                    Name="WE",
                    ProductionYear = 2355,
                    Transmission = Core.TransmissionType.Manual
                },
                new BO.Car()
                {
                    Id = 3,
                    Producer = producers[1],
                    Name="Rumba",
                    ProductionYear = 2312,
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