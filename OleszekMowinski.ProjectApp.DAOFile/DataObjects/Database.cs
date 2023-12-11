using OleszekMowinski.ProjectApp.DAOSQL.DataObjects;
using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.DAOFile.DataObjects
{
    [Serializable]
    internal class Database
    {
        public List<Airplane> Airplanes { get; set; } = new List<Airplane>();
        public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
    }
}
