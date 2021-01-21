using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Models;
using Services.Wrappers;

namespace Services.Queries
{
    public class GetAllCarsQuery : BaseRequest, IRequestWrapper<IEnumerable<CarOverview>>
    { }

    public class GetAllCarsQueryHandler : IHandlerWrapper<GetAllCarsQuery, IEnumerable<CarOverview>>
    {
        public GetAllCarsQueryHandler()
        {
            
        }

        public async Task<Response<IEnumerable<CarOverview>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarOverview> cars = new []
            {
                new CarOverview { Model = $"Tesla {request.UserId}" },
                new CarOverview { Model = "BMW" }
            };

            return Response.Ok(cars);
        }
    }
}