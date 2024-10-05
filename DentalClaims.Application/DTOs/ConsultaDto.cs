using DentalClaims.Domain.Models;

namespace DentalClaims.Application.DTOs;

public record ConsultaDto(
    int Id,
    string Dentista,
    string CRODentista,
    DateOnly DataConsulta,
    TimeOnly HorarioConsulta,
    string? Observacoes,
    StatusConsulta Status);

