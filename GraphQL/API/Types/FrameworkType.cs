using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.DataLoaders;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace API.Types
{
    public class FrameworkType : ObjectType<Framework>
    {
        protected override void Configure(IObjectTypeDescriptor<Framework> descriptor)
        {
            descriptor
                .Field(f => f.Features)
                .ResolveWith<FrameworkResolvers>(f => f.GetFeaturesAsync(default!, default!, default))
                .Name("features");
        }

        private class FrameworkResolvers
        {
            public async Task<IEnumerable<Feature>> GetFeaturesAsync(
                Framework framework,
                [Service] IFrameworkRepository repository,
                CancellationToken cancellationToken)
            {
                return await repository.GetFrameworkFeatures(framework.Id);
            }
        }
    }
}