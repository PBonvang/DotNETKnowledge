using System.Threading.Tasks;
using API.Common;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace API.Users
{
    [ExtendObjectType(Name = RequestTypes.Mutation)]
    public class UserMutations
    {
        public async Task<AddUserPayload> AddUserAsync(
            AddUserInput input,
            [Service] IUserRepository repository)
        {
            // if (string.IsNullOrEmpty(input.Name))
            //     return new AddFeaturePayload(
            //         new UserError("User name cannot be empty", "NAME_EMPTY")
            //     );

            var user = new User
            {
                Name = input.Name
            };

            await repository.InsertUser(user);

            return new AddUserPayload(user);
        }
    }
}