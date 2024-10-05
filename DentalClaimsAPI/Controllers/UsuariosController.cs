using DentalClaims.Application.DTOs;
using DentalClaims.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DentalClaimsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuariosController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] CriarUsuarioDto criarUsuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _usuarioServico.CriarUsuarioAsync(criarUsuarioDto);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuario = await _usuarioServico.ObterUsuarioPorIdAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpGet("{id}/consultas")]
        public async Task<ActionResult<IEnumerable<ConsultaDto>>> GetConsultas(int id)
        {
            var consultas = await _usuarioServico.ObterConsultasDoUsuarioAsync(id);
            return Ok(consultas);
        }
    }
}