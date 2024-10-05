namespace DentalClaims.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task DeletarAsync(int id);
        Task<T?> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T?> ObterPorIdComConsultas(int id);
    }
}   