using Domain.Interfaces;

namespace Domain.Model
{
    //Модель продукта
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Maker Maker { get; set; }
        public List<Category> Categories { get; set; }
        public List<Feature> Features { get; set; }
        public DateTime DateOfProduction { get; set; }
        public DateTime Warranty { get; set; }
    }
}
