using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Frameworks
{
    public class FrameworkPayloadBase : Payload
    {
        public Framework Framework { get; }
        protected FrameworkPayloadBase(Framework framework)
        {
            Framework = framework;
        }
        protected FrameworkPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {}
    }
}