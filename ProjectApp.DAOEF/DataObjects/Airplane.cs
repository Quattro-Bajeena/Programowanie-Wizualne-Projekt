using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OleszekMowinski.ProjectApp.DAOEF.DataObjects
{
    public class Airplane : IAirplane
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Introduction { get; set; }
        public int Weight { get; set; }
        public AirplaneStatus Status { get; set; }

        
        [NotMapped]
        public IManufacturer Manufacturer { get => ManufacturerEf; set { ManufacturerEf = (Manufacturer)value; } }
        [Column("Manufacturer")]
        public Manufacturer ManufacturerEf { get; set; }
        [ForeignKey("Manufacturer")]
        public Guid ManufacturerId { get; set; }
    }
}
