using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FrameworkUserLink> FrameworkUserLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../DataAccess/framework.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Framework>()
                    .HasMany(x => x.Users)
                    .WithMany(x => x.Frameworks)
                    .UsingEntity<FrameworkUserLink>(
                        x => x.HasOne(xs => xs.User).WithMany(),
                        x => x.HasOne(xs => xs.Framework).WithMany())
                    .HasKey(x => new { x.UserId, x.FrameworkId });
        }
    }
}