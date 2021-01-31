using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Frameworks
{
    public class AddFrameworkPayload : FrameworkPayloadBase
    {
        public AddFrameworkPayload(Framework framework) 
            : base(framework)
        {}
        public AddFrameworkPayload(IReadOnlyList<UserError> errors) 
            : base(errors)
        {}
    }    
}