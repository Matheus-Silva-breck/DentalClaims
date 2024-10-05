using DentalClaims.Application.DTOs;
using FluentValidation;

namespace DentalClaims.Application.Validators
{
    public class ConsultaDtoValidator : AbstractValidator<ConsultaDto>
    {
        public ConsultaDtoValidator()
        {
            RuleFor(x => x.Dentista)
                .NotEmpty().WithMessage("O nome do dentista é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do dentista deve ter no máximo 100 caracteres.");

            RuleFor(x => x.CRODentista)
                .NotEmpty().WithMessage("O CRO do dentista é obrigatório.")
                .Matches(@"^\d+$").WithMessage("O CRO deve conter apenas números.");

            RuleFor(x => x.DataConsulta)
                .NotEmpty().WithMessage("A data da consulta é obrigatória.");

            RuleFor(x => x.HorarioConsulta)
                .NotEmpty().WithMessage("O horário da consulta é obrigatório.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("O status da consulta é inválido.");
        }
    }
}