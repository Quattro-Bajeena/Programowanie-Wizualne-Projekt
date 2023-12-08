using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.Interfaces
{
    public interface IManufacturer
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime Founded { get; set; }
        string Headquarters { get; set; }
        string President { get; set; }
    }
}
