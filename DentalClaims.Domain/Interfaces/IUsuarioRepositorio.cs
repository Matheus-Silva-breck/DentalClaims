using DentalClaims.Domain.Models;

namespace DentalClaims.Domain.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> CriarAsync(Usuario usuario);
        Task<Usuario> ObterPorIdAsync(int id);
        Task<List<ConsultaOdontologica>> ObterConsultasDoUsuarioAsync(int usuarioId);
    }
}
