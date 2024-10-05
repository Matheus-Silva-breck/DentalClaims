using DentalClaims.Domain.Interfaces;
using DentalClaims.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClaims.Infrastructure.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id)
                ?? throw new Exception("Usuário não encontrado.");
        }

        public async Task<List<ConsultaOdontologica>> ObterConsultasDoUsuarioAsync(int usuarioId)
        {
            return await _context.Consultas
                .Where(c => c.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}