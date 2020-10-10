using Microsoft.EntityFrameworkCore;
using SmsMessagesMicroService.Models.Models;

namespace SmsMessagesMicroService.Repository
{
    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext(DbContextOptions<MessagesDbContext> options) : base(options)
        { }

        public DbSet<SmsMessages> SmsMessages { get; set; }
    }
}
