using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using GreenDonut;
using HotChocolate.DataLoader;

namespace API.DataLoaders
{
    public class FeatureByIdDataLoader : BatchDataLoader<Guid, Feature>
    {
        private readonly IFeatureRepository _repository;

        public FeatureByIdDataLoader(
            IBatchScheduler batchScheduler,
            IFeatureRepository repository
            )
            : base(batchScheduler)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Feature>> LoadBatchAsync(
            IReadOnlyList<Guid> ids,
            CancellationToken cancellationToken)
        {
            var frameworks = await _repository.GetFeatures(ids, cancellationToken);
            return frameworks;
        }
    }
}