using System;
using DataAccess.Entities;
using HotChocolate.Types.Relay;

namespace API.Frameworks
{
    public record RegisterUserInput(
        [ID(nameof(Framework))]
         Guid FrameworkId,
         [ID(nameof(User))]
         Guid UserId
    );
    
}