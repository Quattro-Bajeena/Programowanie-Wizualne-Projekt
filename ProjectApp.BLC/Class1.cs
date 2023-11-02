using ProjectApp.Interfaces;
using System.Reflection;

namespace ProjectApp.BLC
{
    //Buisness logic component
    public class BLC
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
            Type? typeToCreate = null;
            var assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach ( var type in assembly.GetTypes())
            {
                if(type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }

            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);


        }

        public IEnumerable<IProducer> GetProducers()
        {
            return dao.GetProducers();
        }

        public IEnumerable<ICar> GetCars()
        {
            return dao.GetAllCars();
        }
    }
}