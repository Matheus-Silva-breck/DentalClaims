using DentalClaims.Application.DTOs;

namespace DentalClaims.Application.Interface
{
    public interface IUsuarioServico
    {
        Task<UsuarioDto> CriarUsuarioAsync(CriarUsuarioDto dto);
        Task<UsuarioDto> ObterUsuarioPorIdAsync(int id);
        Task<List<ConsultaDto>> ObterConsultasDoUsuarioAsync(int usuarioId);
    }
}