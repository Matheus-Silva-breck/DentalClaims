namespace DentalClaims.Domain.Models;

public class Usuario
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public string? CPF { get; set; }
    public DateOnly DataNascimento { get; set; }
    public List<ConsultaOdontologica> Consultas { get; set; } = new();
    public required string Senha { get; set; }  
}