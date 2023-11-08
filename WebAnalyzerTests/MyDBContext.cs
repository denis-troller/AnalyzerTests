using Microsoft.EntityFrameworkCore;

namespace WebAnalyzerTests
{
    public class MyDBContext : DbContext
    {
        public DbSet<Entity1> Entity1s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity1>();
        }
    }
}
