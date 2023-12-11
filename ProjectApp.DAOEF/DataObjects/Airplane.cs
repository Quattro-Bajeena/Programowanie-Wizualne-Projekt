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
        IManufacturer IAirplane.Manufacturer { get => Manufacturer; set => Manufacturer = (Manufacturer)value; }
        [Column("Manufacturer")]
        [ForeignKey("ManufacturerIdEF")]
        public Manufacturer Manufacturer { get; set; }
        [Column("ManufacturerIdEF")]
        public Guid ManufacturerIdEF { get; set; }
        [NotMapped]
        public Guid ManufacturerId { get => ManufacturerIdEF; set => ManufacturerIdEF = value; }
    }
}
