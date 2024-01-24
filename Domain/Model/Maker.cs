using Domain.Interfaces;

namespace Domain.Model
{
    public class Maker : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
