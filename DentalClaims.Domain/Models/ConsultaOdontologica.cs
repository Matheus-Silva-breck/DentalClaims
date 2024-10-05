namespace DentalClaims.Domain.Models;

public class ConsultaOdontologica
{
    public int Id { get; set; }
    public required string Dentista { get; set; }
    public required string CRODentista { get; set; }
    public DateOnly DataConsulta { get; set; }
    public TimeOnly HorarioConsulta { get; set; }
    public string? Observacoes { get; set; }
    public required Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
    public List<Tratamento> Tratamentos { get; set; } = new();
    public StatusConsulta Status { get; set; }
}