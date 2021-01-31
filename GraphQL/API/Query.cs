using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using HotChocolate;

namespace API
{
    public class Query
    {
        public async Task<IQueryable<Framework>?> GetFrameworks([Service] IFrameworkRepository repository) 
            => (await repository.GetFrameworks())?.AsQueryable();
    }
}