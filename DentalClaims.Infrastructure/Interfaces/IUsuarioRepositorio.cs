using DentalClaims.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentalClaims.Infrastructure.Interfaces
{
    public interface IUsuarioServico
    {
        Task<UsuarioDto> CriarUsuarioAsync(CriarUsuarioDto dto);
        Task<UsuarioDto> ObterUsuarioPorIdAsync(int id);
        Task<List<ConsultaDto>> ObterConsultasDoUsuarioAsync(int usuarioId);
    }
}
