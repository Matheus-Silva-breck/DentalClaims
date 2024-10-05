namespace DentalClaims.Domain.Models;

public class Previsao
{
    public int Id { get; set; }
    public required Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
    public required string ResultadoPrevisao { get; set; }
    public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
}