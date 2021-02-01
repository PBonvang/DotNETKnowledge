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

namespace API.Users
{
    [ExtendObjectType(Name = RequestTypes.Query)]
    public class UserQueries
    {
        public async Task<List<User>> GetUsersAsync([Service] IUserRepository repository)
            => await repository.GetUsers();

        public async Task<IEnumerable<User>> GetUsersByIdAsync(
            [ID(nameof(User))]Guid[] ids,
            UserByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                await dataLoader.LoadAsync(ids, cancellationToken);

        public async Task<User> GetUserAsync(
            [ID(nameof(User))]Guid id,
            UserByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
                await dataLoader.LoadAsync(id, cancellationToken);
    }
}