using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DentalClaims.Application.DTOs
{
    public class CriarUsuarioDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos.")]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; } = string.Empty;
    }
}