using Microsoft.EntityFrameworkCore;
using ServerAPI.Models;

namespace ServerAPI.DbService
{
    public class _DbService : DbContext
    {
        public _DbService(DbContextOptions<_DbService> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
    }
}
