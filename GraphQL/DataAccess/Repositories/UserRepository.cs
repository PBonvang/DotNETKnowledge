using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> InsertUser(User user);
        Task<List<User>> GetUsers();
        Task<IReadOnlyDictionary<Guid, User>> GetUsers(IReadOnlyList<Guid> ids, CancellationToken cancellationToken);
        Task<User> GetUser(Guid id);
        Task<List<Framework>> GetUserFrameworks(Guid id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly EntityContext _db;
        public UserRepository(EntityContext db)
        {
            _db = db;
        }
        public async Task<User> InsertUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<IReadOnlyDictionary<Guid, User>> GetUsers(IReadOnlyList<Guid> ids, CancellationToken cancellationToken)
        {
            var users = await _db.Users
                .Where(u => ids.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, cancellationToken);
            return users;
        }
        public async Task<User> GetUser(Guid id)
        {
            return await _db.Users.FindAsync(id);
        }
        public async Task<List<Framework>> GetUserFrameworks(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            return user.Frameworks;
        }
    }
}