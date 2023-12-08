﻿using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.DAOEF.DataObjects
{
    public class Manufacturer : IManufacturer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string Headquarters { get; set; }
        public string President { get; set; }
        public virtual ICollection<Airplane> Airplanes { get; set; } = new List<Airplane>();
    }
}
