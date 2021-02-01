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
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace API.Features
{
    [ExtendObjectType(Name = RequestTypes.Query)]
    public class FeatureQueries
    {
        [UsePaging(typeof(NonNullType<FeatureType>))]
        public async Task<List<Feature>> GetFeaturesAsync([Service] IFeatureRepository repository)
            => (await repository.GetFeatures())
                .OrderBy(t => t.Name).ToList();

        public async Task<IEnumerable<Feature>> GetFeaturesByIdAsync(
            [ID(nameof(Feature))]Guid[] ids,
            FeatureByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                await dataLoader.LoadAsync(ids, cancellationToken);

        public async Task<Feature> GetFeatureAsync(
            [ID(nameof(Feature))]Guid id,
            FeatureByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                await dataLoader.LoadAsync(id, cancellationToken);
    }
}