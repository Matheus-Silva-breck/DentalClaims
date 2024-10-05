using AutoMapper;
using DentalClaims.Application.DTOs;
using DentalClaims.Application.Interface;
using DentalClaims.Domain.Interfaces;
using DentalClaims.Domain.Models;

namespace DentalClaims.Application.Services
{
    public class UsuarioServico : DentalClaims.Application.Interface.IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> CriarUsuarioAsync(CriarUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var usuarioCriado = await _usuarioRepositorio.CriarAsync(usuario);
            return _mapper.Map<UsuarioDto>(usuarioCriado);
        }

        public async Task<List<ConsultaDto>> ObterConsultasDoUsuarioAsync(int usuarioId)
        {
            var consultas = await _usuarioRepositorio.ObterConsultasDoUsuarioAsync(usuarioId);
            return _mapper.Map<List<ConsultaDto>>(consultas);
        }

        public async Task<UsuarioDto> ObterUsuarioPorIdAsync(int id)
        {
            var usuario = await _usuarioRepositorio.ObterPorIdAsync(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }
    }
}