namespace Domain.Dtos
{
    //Модель dto объекта продукта
    public class ProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public MakerDto Maker { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<FeatureDto> Features { get; set; }
        public DateTime DateOfProduction { get; set; }
        public DateTime Warranty { get; set; }
    }
}
