using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Present.Data
{
    public class ChatSystemContext : IdentityDbContext<ApplicationUser>
    {
        public ChatSystemContext(DbContextOptions<ChatSystemContext> opt) : base(opt) { }
        public DbSet<IndividualChat>? IndividualChats { get; set; }
        public DbSet<Chat>? Chats { get; set; }
    }
   
}
