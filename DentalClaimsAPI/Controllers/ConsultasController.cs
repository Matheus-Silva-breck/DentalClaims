using DentalClaims.Application.DTOs;
using DentalClaims.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DentalClaimsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultasController(IConsultaServico consultaServico)
        {
            _consultaServico = consultaServico;
        }

        [HttpPost("usuario/{usuarioId}")]
        public async Task<ActionResult<ConsultaDto>> AgendarConsulta(int usuarioId, [FromBody] ConsultaDto consultaDto)
        {
            var consulta = await _consultaServico.AgendarConsultaAsync(usuarioId, consultaDto);
            return CreatedAtAction(nameof(ObterConsulta), new { id = consulta.Id }, consulta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDto>> ObterConsulta(int id)
        {
            var consulta = await _consultaServico.ObterConsultaPorIdAsync(id);
            return consulta == null ? NotFound() : Ok(consulta);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<ConsultaDto>>> ObterConsultasPorUsuario(int usuarioId)
        {
            var consultas = await _consultaServico.ObterConsultasPorUsuarioAsync(usuarioId);
            return Ok(consultas);
        }
    }
}