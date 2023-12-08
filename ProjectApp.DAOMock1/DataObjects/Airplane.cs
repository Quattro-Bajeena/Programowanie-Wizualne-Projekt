using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.DAOMock1.DataObjects
{
    internal class Airplane : IAirplane
    {
        public Guid Id { get; set; }
        public string Name { get ; set ; }
        public DateTime Introduction { get; set; }
        public int Weight { get; set; }
        public AirplaneStatus Status { get; set; }
        public IManufacturer Manufacturer { get ; set ; }
    }
}
