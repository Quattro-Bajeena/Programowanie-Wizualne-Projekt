using ProjectApp.Interfaces;

namespace ProjectApp.DAOMock2.BO
{
    public class Producer : IProducer
    {
        public int Id { get; set ; }
        public string Name { get; set ; }
        public string Address { get; set; }
    }
}