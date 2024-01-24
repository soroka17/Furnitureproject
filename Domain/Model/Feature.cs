using Domain.Interfaces;

namespace Domain.Model
{
    public class Feature : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
