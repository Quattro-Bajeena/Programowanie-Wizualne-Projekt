using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using System.Reflection;

namespace OleszekMowinski.ProjectApp.BLC
{
    //Buisness logic component
    public class BuisnessLogicComponent
    {
        private readonly IDAO dao = null!;

        public BuisnessLogicComponent(string libraryName)
        {
            Type? typeToCreate = null;
            var assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }
            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public IEnumerable<IAirplane> GetAirplanes() => dao.GetAirplanes();
        public IEnumerable<IManufacturer> GetManufacturers() => dao.GetManufacturers();
        public IAirplane CreateNewAirplane(IAirplane airplane) => dao.CreateNewAirplane(airplane);
        public IManufacturer CreateNewManufacturer(IManufacturer manufacturer) => dao.CreateNewManufacturer(manufacturer);
        public IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId) => dao.CreateNewAirplane(name, introduction, weight, status, manufacturerId);
        public IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president) => dao.CreateNewManufacturer(name, founded, headquaters, president);
        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter) => dao.GetFilteredAirplanes(filter);
        public IAirplane EditAirplane(Guid id, string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId) => dao.EditAirplane(id, name, introduction, weight, status, manufacturerId);
        public IManufacturer EditManufacturer(Guid id, string name, DateTime founded, string headquaters, string president) => dao.EditManufacturer(id, name, founded, headquaters, president);
        public IAirplane EditAirplane(IAirplane airplane) => dao.EditAirplane(airplane);
        public IManufacturer EditManufacturer(IManufacturer manufacturer) => dao.EditManufacturer(manufacturer);
        public void DeleteAirplane(Guid id) => dao.DeleteAirplane(id);
        public void DeleteManufacturer(Guid id) => dao.DeleteManufacturer(id);
        public IAirplane? GetAirplane(Guid id) => dao.GetAirplane(id);
        public IManufacturer? GetManufacturer(Guid id) => dao.GetManufacturer(id);


    }
}