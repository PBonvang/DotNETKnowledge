using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace API.Frameworks
{
    [ExtendObjectType(Name = "Mutation")]
    public class FrameworkMutations
    {
        public async Task<AddFrameworkPayload> AddFrameworkAsync(
            AddFrameworkInput input,
            [Service] IFrameworkRepository repository)
        {
            var framework = new Framework
            {
                Name = input.Name,
                Description = input.Description
            };

            await repository.InsertFramework(framework);

            return new AddFrameworkPayload(framework);
        }
    }
}