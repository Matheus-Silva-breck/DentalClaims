using DentalClaims.Application.DTOs;
using FluentValidation;

namespace DentalClaims.Application.Validators
{
    public class CriarUsuarioDtoValidator : AbstractValidator<CriarUsuarioDto>
    {
        public CriarUsuarioDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail deve ser válido.");

            RuleFor(x => x.Cpf) 
                .Matches(@"^\d{11}$").WithMessage("O CPF deve ter 11 dígitos.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(data => data <= DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("A data de nascimento não pode ser no futuro.");
        }
    }
}
