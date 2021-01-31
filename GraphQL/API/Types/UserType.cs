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
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                 .ImplementsNode()
                 .IdField(t => t.Id)
                 .ResolveNode((ctx, id) => ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(f => f.Frameworks)
                .ResolveWith<UserResolvers>(f => f.GetFrameworksAsync(default!, default!, default))
                .Name("frameworks");
        }

        private class UserResolvers
        {
            public async Task<IEnumerable<Framework>> GetFrameworksAsync(
                User User,
                [Service] IUserRepository repository,
                CancellationToken cancellationToken)
            {
                return await repository.GetUserFrameworks(User.Id);
            }
        }
    }
}