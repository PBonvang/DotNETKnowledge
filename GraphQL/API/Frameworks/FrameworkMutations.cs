using System.Threading;
using System.Threading.Tasks;
using API.Common;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace API.Frameworks
{
    [ExtendObjectType(Name = RequestTypes.Mutation)]
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

        public async Task<UpdateFrameworkDescriptionPayload> UpdateFrameworkDescriptionsAsync(
            UpdateFrameworkDescriptionInput input,
            [Service] IFrameworkRepository repository,
            [Service]ITopicEventSender eventSender)
        {
            var framework = await repository.GetFramework(input.FrameworkId);

            if (framework is null)
                return new UpdateFrameworkDescriptionPayload(
                    new UserError("Framework not found.", "FRAMEWORK_NOT_FOUND")); 

            framework.Description = input.Description;
            await repository.UpdateFramework(framework);

            await eventSender.SendAsync(
                nameof(FrameworkSubscriptions.OnFrameworkDescriptionUpdatedAsync),
                framework.Id);

            return new UpdateFrameworkDescriptionPayload(framework);
        }

        public async Task<RegisterUserPayload> RegisterFrameworkUserAsync(
            RegisterUserInput input,
            [Service] IFrameworkRepository frameworkRepository,
            [Service] IUserRepository userRepository,
            CancellationToken cancellationToken)
        {
            Framework framework = await frameworkRepository.GetFramework(input.FrameworkId);

            if (framework is null)
            {
                return new RegisterUserPayload(
                    new UserError("Framework not found.", "FRAMEWORK_NOT_FOUND"));
            }

            await frameworkRepository.RegisterUser(input.FrameworkId, input.UserId);

            return new RegisterUserPayload(framework, input.UserId);
        }
    }
}