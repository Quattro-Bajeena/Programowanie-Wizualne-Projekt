using OleszekMowinski.ProjectApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IAirplane> GetAirplanes();
        IEnumerable<IManufacturer> GetManufacturer();
        IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId);
        IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president);
        IAirplane ModifyAirplane(IAirplane airplane);
        IManufacturer ModifyManufacturer(IManufacturer manufacturer);
        IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter);

        void DeleteAirplane(Guid id);
        void DeleteManufacturer(Guid id);
    }
}
