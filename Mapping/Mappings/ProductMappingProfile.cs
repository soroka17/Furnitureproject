using AutoMapper;
using Domain.Dtos;
using Domain.Model;

namespace Mapping.Mappings
{
    public class ProductMappingProfile : Profile
    {
        //Правила маппинг объекта Dto в его обычный вариант(присваем случайный id, все остальное AutoMapper сделает сам, из-за одинаковых названий полей в объектаъх)
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()));
        }
    }
}
