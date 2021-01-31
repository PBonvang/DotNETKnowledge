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
    public class FrameworkByIdDataLoader : BatchDataLoader<Guid, Framework>
    {
        private readonly IFrameworkRepository _repository;

        public FrameworkByIdDataLoader(
            IBatchScheduler batchScheduler,
            IFrameworkRepository repository
            )
            : base(batchScheduler)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Framework>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var frameworks = await _repository.GetFrameworks(keys, cancellationToken);
            return frameworks;
        }
    }
}