using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetProducers();
        IEnumerable<ICar> GetAllCars();
        IProducer CreateNewProducer();
        ICar CreateNewCar();
    }
}
