using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Common;
using API.DataLoaders;
using DataAccess.Entities;

namespace API.Frameworks
{
    public class RegisterUserPayload : FrameworkPayloadBase
    {
        private Guid? _userId;
        public RegisterUserPayload(Framework framework, Guid userId)
            : base(framework)
        {
            _userId = userId;
        }
        public RegisterUserPayload(UserError error)
            : base(new[] { error })
        { }
        public async Task<User> GetUserAsync(
             UserByIdDataLoader userById,
             CancellationToken cancellationToken)
        {
            if (_userId.HasValue)
                return await userById.LoadAsync(_userId.Value, cancellationToken);

            return null;
        }
    }
}