using Present.Data;

namespace Present.Repository.Interface
{
    public interface IChatRepository : IGenericRepository<Chat, string>

    {
        Task<IQueryable<Chat>> GetMessageOfUser(string userId);
    }
}
