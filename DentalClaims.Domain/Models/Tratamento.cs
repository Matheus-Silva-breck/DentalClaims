namespace DentalClaims.Domain.Models
{
    public class Tratamento
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public decimal Custo { get; set; }
        public required ConsultaOdontologica Consulta { get; set; }
        public int ConsultaId { get; set; }
    }
}
