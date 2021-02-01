using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Features
{
    public class FeaturePayloadBase : Payload
    {
        public Feature Feature { get; }
        protected FeaturePayloadBase(Feature feature)
        {
            Feature = feature;
        }
        protected FeaturePayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {}
    }
}