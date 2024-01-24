using AutoMapper;
using Domain.Dtos;
using Domain.Model;

namespace Mapping.Mappings
{
    public class MakerMappingProfile : Profile
    {
        public MakerMappingProfile()
        {
            CreateMap<MakerDto, Maker>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()));
        }
    }
}
