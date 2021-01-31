using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Framework> Frameworks { get; set; } = default!;
        public DbSet<Feature> Features { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../DataAccess/framework.db");
    }
}