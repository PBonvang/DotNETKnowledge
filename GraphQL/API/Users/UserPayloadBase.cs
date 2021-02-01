using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Users
{
    public class UserPayloadBase : Payload
    {
        public User User { get; }
        protected UserPayloadBase(User user)
        {
            User = user;
        }
        protected UserPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {}
    }
}