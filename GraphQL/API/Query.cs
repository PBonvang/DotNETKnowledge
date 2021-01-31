using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.DataLoaders;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;

namespace API
{
    public class Query
    {
        public async Task<List<Framework>> GetFrameworks([Service] IFrameworkRepository repository)
            => await repository.GetFrameworks();
        
        public Task<Framework> GetFrameworkAsync(
            Guid id,
            FrameworkByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                dataLoader.LoadAsync(id, cancellationToken);
    }
}