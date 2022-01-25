using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace targilDotNet
{
    public class KeyPressContext:DbContext

    {
        private readonly IConfiguration _configuration;
        public KeyPressContext(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        public DbSet<Key> Keys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=targilDotNetData2");
            //base.OnConfiguring(optionsBuilder);

        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>()
                .HasKey(b => new { b._keyName, b._startTimeastamp });
          
        }
    }
}
