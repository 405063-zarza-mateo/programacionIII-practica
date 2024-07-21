using AutoMapper;
using deportesApi.Dtos;
using deportesApi.models;

namespace deportesApi
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Socio, SocioDto>().ForMember(dest => dest.nombreDeporte, opt => opt.MapFrom(src => src.IdDeporteNavigation.Nombre));
            CreateMap<SocioPostDto, Socio>();
            CreateMap<Deporte, DeporteDto>();
            CreateMap<DeporteDto, Deporte>();
        }
    }
}
