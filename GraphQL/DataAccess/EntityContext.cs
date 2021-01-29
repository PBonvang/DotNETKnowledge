using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../DataAccess/framework.db");
    }
}