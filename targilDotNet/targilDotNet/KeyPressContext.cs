using Microsoft.EntityFrameworkCore;

namespace targilDotNet
{
    public class KeyPressContext:DbContext

    {

        public KeyPressContext()
        {

        }
        public DbSet<girl> girls { get; set; }
        public DbSet<Key> Keys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=targilDotNetData");
            //base.OnConfiguring(optionsBuilder);

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>()
                .HasKey(b => new { b.KeyName, b.startTimeastamp });
            modelBuilder.Entity<girl>().ToTable("girlses");
        }
    }
}
