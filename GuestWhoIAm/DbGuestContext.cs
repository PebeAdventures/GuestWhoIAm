using GuestWhoIAm.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestWhoIAm
{
    public class DbGuestContext : DbContext
    {
        public DbGuestContext(DbContextOptions<DbGuestContext> options) : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
