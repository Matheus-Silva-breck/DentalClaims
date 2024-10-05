using DentalClaims.Application.DTOs;

namespace DentalClaims.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public string? CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public List<ConsultaDto>? Consultas { get; set; }
    }
}