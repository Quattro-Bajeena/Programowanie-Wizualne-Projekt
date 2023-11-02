using ProjectApp.BLC;

namespace ProjectApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            var blc = new BLC.BLC(libraryName);

            foreach (var producer in blc.GetProducers())
            {
                Console.WriteLine($"{producer.Id}: {producer.Name}");
            }
            Console.WriteLine("--------------");

            foreach(var car in blc.GetCars())
            {
                Console.WriteLine($"{car.Id}: {car.Name} {car.Transmission} {car.Producer} {car.ProductionYear}");
            }
        }
    }
}