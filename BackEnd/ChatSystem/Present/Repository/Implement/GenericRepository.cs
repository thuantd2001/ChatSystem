using Present.Data;
using Present.Repository.Interface;

namespace Present.Repository.Implement
{
    public class GenericRepository<T, k> : IGenericRepository<T, k> where T : class
    {
        private readonly ChatSystemContext _context;
        public GenericRepository(ChatSystemContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await Save();
            return  entity;
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(k id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(k id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
