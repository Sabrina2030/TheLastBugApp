using AutoMapper;
using TheLastBug.Business.DTOs;
using TheLastBug.Domain.Models;

namespace TheLastBug.Business.Mappers
{
    public class MappingProfile : Profile   
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuariosConAyudasDTO>();
            CreateMap<UsuariosConAyudasDTO, Usuario>();
            CreateMap<Region, RegionDTO>();
            CreateMap<RegionDTO, Region>();
            CreateMap<Comuna, ComunaDTO>();
            CreateMap<ComunaDTO, Comuna>();
            CreateMap<Pais, PaisDTO>();
            CreateMap<PaisDTO, Pais>();
            CreateMap<AyudaSocial, AyudaSocialDTO>();
            CreateMap<AyudaSocialDTO, AyudaSocial>();
            CreateMap<Log, LogDTO>();
            CreateMap<LogDTO, Log>();
        }
    }
}
