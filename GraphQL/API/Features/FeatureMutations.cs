using System.Threading.Tasks;
using API.Common;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace API.Features
{
    [ExtendObjectType(Name = RequestTypes.Mutation)]
    public class FeatureMutations
    {
        public async Task<AddFeaturePayload> AddFeatureAsync(
            AddFeatureInput input,
            [Service] IFeatureRepository repository)
        {
            // if (string.IsNullOrEmpty(input.Name))
            //     return new AddFeaturePayload(
            //         new UserError("Feature name cannot be empty", "NAME_EMPTY")
            //     );

            var feature = new Feature
            {
                Name = input.Name,
                Description = input.Description
            };

            await repository.InsertFeature(feature);

            return new AddFeaturePayload(feature);
        }
    }
}