using AutoMapper;
using Domain.Dtos;
using Domain.Model;

namespace Mapping.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()));
        }
    }
}
