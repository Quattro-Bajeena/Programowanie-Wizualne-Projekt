using OleszekMowinski.ProjectApp.Core;

namespace OleszekMowinski.ProjectApp.Interfaces
{
    public interface IDAO
    {
        IAirplane? GetAirplane(Guid id);
        IManufacturer? GetManufacturer(Guid id);
        IEnumerable<IAirplane> GetAirplanes();
        IEnumerable<IManufacturer> GetManufacturers();
        IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId);
        IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president);
        IAirplane? EditAirplane(Guid id, string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId);
        IManufacturer? EditManufacturer(Guid id, string name, DateTime founded, string headquaters, string president);
        IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter);
        void DeleteAirplane(Guid id);
        void DeleteManufacturer(Guid id);
    }
}
