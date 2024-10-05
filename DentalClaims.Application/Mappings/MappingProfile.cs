using AutoMapper;
using DentalClaims.Domain.Models;
using DentalClaims.Application.DTOs;

namespace DentalClaims.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CriarUsuarioDto, Usuario>();
            CreateMap<ConsultaOdontologica, ConsultaDto>();
        }
    }
}