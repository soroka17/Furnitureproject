using Domain.Interfaces;

namespace Domain.Model
{
    
    public class Category : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
