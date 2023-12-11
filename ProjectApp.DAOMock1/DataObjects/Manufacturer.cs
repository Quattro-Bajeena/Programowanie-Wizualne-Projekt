using OleszekMowinski.ProjectApp.Interfaces;

namespace OleszekMowinski.ProjectApp.DAOMock1.DataObjects
{
    internal class Manufacturer : IManufacturer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string Headquarters { get; set; }
        public string President { get; set; }
    }
}
