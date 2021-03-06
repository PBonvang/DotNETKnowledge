using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Common;
using API.DataLoaders;
using API.Types;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace API.Frameworks
{
    [ExtendObjectType(Name = RequestTypes.Query)]
    public class FrameworkQueries
    {
        [UsePaging(typeof(NonNullType<FrameworkType>))]
        [UseFiltering(typeof(FrameworkFilterInputType))]
        [UseSorting]
        public async Task<List<Framework>> GetFrameworksAsync([Service] IFrameworkRepository repository)
            => (await repository.GetFrameworks())
                .OrderBy(f => f.Name).ToList();

        public async Task<IEnumerable<Framework>> GetFrameworksByIdAsync(
            [ID(nameof(Framework))] Guid[] ids,
            FrameworkByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                await dataLoader.LoadAsync(ids, cancellationToken);

        public async Task<Framework> GetFrameworkAsync(
            [ID(nameof(Framework))] Guid id,
            FrameworkByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                await dataLoader.LoadAsync(id, cancellationToken);
    }
}