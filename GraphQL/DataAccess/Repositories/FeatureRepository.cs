using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public interface IFeatureRepository
    {
        Task<List<Feature>?> GetFeatures();
        Task<Feature?> GetFeature(Guid id);
    }
    public class FeatureRepository : IFeatureRepository
    {
        private readonly EntityContext _db;
        public FeatureRepository(EntityContext db)
        {
            _db = db;
        }

        public async Task<List<Feature>?> GetFeatures()
        {
            return await _db.Features.ToListAsync();
        }
        public async Task<Feature?> GetFeature(Guid id)
        {
            return await _db.Features.FindAsync(id);
        }
    }
}