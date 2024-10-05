using DentalClaims.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClaims.Infrastructure.Repositories
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AtualizarAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T?> ObterPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual T? ObterPorIdComConsultas(int id)
        {
            // Este método deve ser sobrescrito na implementação específica
            throw new NotImplementedException();
        }

        Task<T?> IRepositorio<T>.ObterPorIdComConsultas(int id)
        {
            throw new NotImplementedException();
        }
    }
}