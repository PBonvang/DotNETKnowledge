using System.Collections.Generic;
using API.Common;
using DataAccess.Entities;

namespace API.Users
{
    public class AddUserPayload : UserPayloadBase
    {
        public AddUserPayload(User user) 
            : base(user)
        {}
        public AddUserPayload(UserError error) 
            : base(new[] {error})
        {}
    }    
}