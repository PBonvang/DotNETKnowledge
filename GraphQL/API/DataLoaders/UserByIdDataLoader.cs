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
    public class UserByIdDataLoader : BatchDataLoader<Guid, User>
    {
        private readonly IUserRepository _repository;

        public UserByIdDataLoader(
            IBatchScheduler batchScheduler,
            IUserRepository repository)
            : base(batchScheduler)
        {
            _repository = repository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, User>> LoadBatchAsync(
            IReadOnlyList<Guid> ids,
            CancellationToken cancellationToken)
        {
            var frameworks = await _repository.GetUsers(ids, cancellationToken);
            return frameworks;
        }
    }
}