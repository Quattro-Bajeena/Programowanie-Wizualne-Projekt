using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using System.Text.Json.Serialization;

namespace OleszekMowinski.ProjectApp.DAOSQL.DataObjects
{
    [Serializable]
    internal class Airplane : IAirplane
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Introduction { get; set; }
        public int Weight { get; set; }
        public AirplaneStatus Status { get; set; }
        [JsonIgnore]
        public IManufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }
    }
}
