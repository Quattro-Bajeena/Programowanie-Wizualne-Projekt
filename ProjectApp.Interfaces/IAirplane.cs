using OleszekMowinski.ProjectApp.Core;

namespace OleszekMowinski.ProjectApp.Interfaces
{
    public interface IAirplane
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime Introduction { get; set; }
        int Weight { get; set; }
        AirplaneStatus Status { get; set; }
        Guid ManufacturerId { get; set; }
        IManufacturer Manufacturer { get; set; }

    }
}
