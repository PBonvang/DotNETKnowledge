using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Frameworks
{
    public class UpdateFrameworkDescriptionPayload : FrameworkPayloadBase
    {
        public UpdateFrameworkDescriptionPayload(Framework framework) 
            : base(framework)
        {}
        public UpdateFrameworkDescriptionPayload(UserError error) 
            : base(new[] {error})
        {}
    }    
}