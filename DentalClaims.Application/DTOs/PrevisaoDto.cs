namespace DentalClaims.Application.DTOs
{
    public class PrevisaoDto
    {
        public int Id { get; set; }
        public DateTime DataPrevista { get; set; }
        public required string Descricao { get; set; }
        public int ConsultaId { get; set; }
    }
}
