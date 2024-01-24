using AutoMapper;
using Domain.Dtos;
using Domain.Model;

namespace Mapping.Mappings
{
    public class FeaturesMappingProfile : Profile
    {
        public FeaturesMappingProfile()
        {
            CreateMap<FeatureDto, Feature>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()));
        }
    }
}
