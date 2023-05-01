using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Present.Data;
using Present.Repository.Interface;

namespace Present.Repository.Implement
{
    public class ChatRepository : GenericRepository<Chat, string>, IChatRepository
    {
        private readonly ChatSystemContext _context;
        public ChatRepository(
            ChatSystemContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IQueryable<Chat>> GetMessageOfUser(string userId)
        {
            var chats = _context.Chats.Include(c => c.IndividualChat).ThenInclude(i => i.UserReceive)
                .Where(c => c.IndividualChat.UserReceiveId == userId);
            return chats;
        }

    }
}
