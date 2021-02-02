using System;
using DataAccess.Entities;
using HotChocolate.Types.Relay;

namespace API.Frameworks
{
    public record UpdateFrameworkDescriptionInput(
        [ID(nameof(Framework))] Guid FrameworkId,
        string Description
    );
    
}