using ProjectApp.Core;
using ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DAOMock1.BO
{
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Name { get ; set; }
        public IProducer Producer { get ; set; }
        public int ProductionYear { get; set; }
        public TransmissionType Transmission { get; set; }
    }
}
