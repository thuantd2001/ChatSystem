namespace Present.Repository.Interface
{
    public interface IGenericRepository<T,K> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(K id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(K id);
        Task UpdateAsync(T entity);
        Task Save();

    }
}
