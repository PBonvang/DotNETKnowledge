using DataAccess.Entities;

namespace API.Mutations
{
    public class AddFrameworkPayload
    {
        public Framework Framework { get; }
        public AddFrameworkPayload(Framework framework)
        {
            Framework = framework;
        }
    }    
}