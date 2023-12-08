using OleszekMowinski.ProjectApp.BLC;

namespace OleszekMowinski.ProjectApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            var libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            var blc = new BuisnessLogicComponent(libraryName);

            foreach (var manufacturer in blc.GetManufacturer())
            {
                Console.WriteLine($"{manufacturer.Id}: {manufacturer.Name}");
            }
            Console.WriteLine("--------------");

            foreach(var plane in blc.GetAirplanes())
            {
                Console.WriteLine($"{plane.Id}: {plane.Name} {plane.Manufacturer} {plane.Introduction} {plane.Weight}");
            }
        }
    }
}