using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public interface IFrameworkRepository
    {
        Task<Framework> InsertFramework(Framework framework);
        Task<List<Framework>> GetFrameworks();
        Task<IReadOnlyDictionary<Guid, Framework>> GetFrameworks(IReadOnlyList<Guid> ids, CancellationToken cancellationToken);
        Task<Framework> GetFramework(Guid id);
        Task<List<Feature>> GetFrameworkFeatures(Guid id);
        Task<List<User>> GetFrameworkUsers(Guid id);
    }
    public class FrameworkRepository : IFrameworkRepository
    {
        private readonly EntityContext _db;
        public FrameworkRepository(EntityContext db)
        {
            _db = db;
        }

        public async Task<Framework> InsertFramework(Framework framework)
        {
            await _db.Frameworks.AddAsync(framework);
            await _db.SaveChangesAsync();
            return framework;
        }

        public async Task<Framework> GetFramework(Guid id)
        {
            return await _db.Frameworks.FindAsync(id);
        }
        public async Task<IReadOnlyDictionary<Guid, Framework>> GetFrameworks(IReadOnlyList<Guid> ids, CancellationToken cancellationToken)
        {
            var frameworks = await _db.Frameworks
                .Where(f => ids.Contains(f.Id))
                .ToDictionaryAsync(s => s.Id, cancellationToken);

            return frameworks;
        }
        public async Task<List<Framework>> GetFrameworks()
        {
            return await _db.Frameworks.ToListAsync();
        }
        public async Task<List<Feature>> GetFrameworkFeatures(Guid id)
        {
            var framework = await _db.Frameworks.FindAsync(id);
            return framework.Features;
        }
        public async Task<List<User>> GetFrameworkUsers(Guid id)
        {
            var framework = await _db.Frameworks.FindAsync(id);
            return framework.Users;
        }
    }
}