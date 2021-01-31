using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.DataLoaders;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace API.Types
{
    public class FeatureType : ObjectType<Feature>
    {
        protected override void Configure(IObjectTypeDescriptor<Feature> descriptor)
        {
            descriptor
                 .ImplementsNode()
                 .IdField(t => t.Id)
                 .ResolveNode((ctx, id) => ctx.DataLoader<FeatureByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }
    }
}