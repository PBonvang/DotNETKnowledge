using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=car.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("NOCASE");
            modelBuilder.Entity<Car>().Property(x => x.Model).UseCollation("NOCASE");
            modelBuilder.Entity<Brand>().Property(x => x.Name).UseCollation("NOCASE");
        }
        
    }
}