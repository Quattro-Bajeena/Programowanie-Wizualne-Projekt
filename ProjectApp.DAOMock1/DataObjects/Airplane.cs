using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;

namespace OleszekMowinski.ProjectApp.DAOMock1.DataObjects
{
    internal class Airplane : IAirplane
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Introduction { get; set; }
        public int Weight { get; set; }
        public AirplaneStatus Status { get; set; }
        public IManufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
