using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace targilDotNet
{
    public class KeyPressContext : DbContext, IKeyPressContext
    {
        public KeyPressContext(DbContextOptions<KeyPressContext> options) : base(options)
        {
        }

        public DbSet<Key> Keys { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>()
                .HasKey(b => new { b._keyName, b._startTimeastamp });

        }
    }
}
