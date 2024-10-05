namespace DentalClaims.Application.DTOs
{
    public class TratamentoDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public decimal Custo { get; set; }
        public int ConsultaId { get; set; }
    }
}