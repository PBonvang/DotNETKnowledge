using System;
using System.Threading;
using System.Threading.Tasks;
using API.Common;
using API.DataLoaders;
using DataAccess.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace API.Frameworks
{
    [ExtendObjectType(Name = RequestTypes.Subscription)]
    public class FrameworkSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Framework> OnFrameworkDescriptionUpdatedAsync(
            [EventMessage] Guid frameworkId,
            FrameworkByIdDataLoader frameworkById,
            CancellationToken cancellationToken) 
            => frameworkById.LoadAsync(frameworkId, cancellationToken);
    }
}