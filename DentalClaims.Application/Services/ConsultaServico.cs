using AutoMapper;
using DentalClaims.Application.DTOs;
using DentalClaims.Domain.Interfaces;
using DentalClaims.Domain.Models;

namespace DentalClaims.Application.Services
{
    public interface IConsultaServico
    {
        Task<ConsultaDto> AgendarConsultaAsync(int usuarioId, ConsultaDto consultaDto);
        Task<ConsultaDto> ObterConsultaPorIdAsync(int id);
        Task<List<ConsultaDto>> ObterConsultasPorUsuarioAsync(int usuarioId);
    }

    public class ConsultaServico : IConsultaServico
    {
        private readonly IRepositorio<ConsultaOdontologica> _consultaRepositorio;
        private readonly IMapper _mapper;

        public ConsultaServico(IRepositorio<ConsultaOdontologica> consultaRepositorio, IMapper mapper)
        {
            _consultaRepositorio = consultaRepositorio;
            _mapper = mapper;
        }

        public async Task<ConsultaDto> AgendarConsultaAsync(int usuarioId, ConsultaDto consultaDto)
        {
            var consulta = _mapper.Map<ConsultaOdontologica>(consultaDto);
            consulta.UsuarioId = usuarioId;

            var consultaCriada = await _consultaRepositorio.AdicionarAsync(consulta);
            return _mapper.Map<ConsultaDto>(consultaCriada);
        }

        public async Task<ConsultaDto> ObterConsultaPorIdAsync(int id)
        {
            var consulta = await _consultaRepositorio.ObterPorIdAsync(id);
            return _mapper.Map<ConsultaDto>(consulta);
        }

        public async Task<List<ConsultaDto>> ObterConsultasPorUsuarioAsync(int usuarioId)
        {
            var consultas = await _consultaRepositorio.ObterTodosAsync();
            var consultasDoUsuario = consultas.Where(c => c.UsuarioId == usuarioId).ToList();
            return _mapper.Map<List<ConsultaDto>>(consultasDoUsuario);
        }
    }
}