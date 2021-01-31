using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>?> GetUsers();
        Task<User?> GetUser(Guid id);
        Task<List<Framework>?> GetUserFrameworks(Guid id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly EntityContext _db;
        public UserRepository(EntityContext db)
        {
            _db = db;
        }

        public async Task<List<User>?> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<User?> GetUser(Guid id)
        {
            return await _db.Users.FindAsync(id);
        }
        public async Task<List<Framework>?> GetUserFrameworks(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            return user.Frameworks;
        }
    }
}