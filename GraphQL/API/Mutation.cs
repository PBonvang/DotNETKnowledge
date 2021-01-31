using System.Threading.Tasks;
using API.Mutations;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;

namespace API
{
    public class Mutation
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