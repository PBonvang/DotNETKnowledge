using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public interface IFrameworkRepository
    {
        Task<List<Framework>> GetFrameworks();
        Task<Framework> GetFramework(Guid id);
        Task<List<User>> GetFrameworkUsers(Guid id);
    }
    public class FrameworkRepository : IFrameworkRepository
    {
        private readonly EntityContext _db;
        public FrameworkRepository(EntityContext db)
        {
            _db = db;
        }

        public async Task<Framework> GetFramework(Guid id)
        {
            return await _db.Frameworks.FindAsync(id);
        }

        public async Task<List<Framework>> GetFrameworks()
        {
            return await _db.Frameworks.ToListAsync();
        }

        public async Task<List<User>> GetFrameworkUsers(Guid id)
        {
            var framework = await _db.Frameworks.FindAsync(id);
            return framework.Users;
        }
    }
}