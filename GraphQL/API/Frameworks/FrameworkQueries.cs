using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Common;
using API.DataLoaders;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace API.Frameworks
{
    [ExtendObjectType(Name = RequestTypes.Query)]
    public class FrameworkQueries
    {
        public async Task<List<Framework>> GetFrameworks([Service] IFrameworkRepository repository)
            => await repository.GetFrameworks();
        
        public Task<Framework> GetFrameworkAsync(
            [ID(nameof(Framework))]Guid id,
            FrameworkByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                dataLoader.LoadAsync(id, cancellationToken);
    }
}