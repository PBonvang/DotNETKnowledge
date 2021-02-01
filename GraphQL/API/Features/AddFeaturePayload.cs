using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Features
{
    public class AddFeaturePayload : FeaturePayloadBase
    {
        public AddFeaturePayload(Feature feature) 
            : base(feature)
        {}
        public AddFeaturePayload(UserError error) 
            : base(new[] {error})
        {}
    }    
}