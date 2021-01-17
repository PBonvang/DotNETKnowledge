using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Models;
using Services.Wrappers;

namespace Services.Queries
{
    public class GetAllCarsQuery : BaseRequest, IRequestWrapper<IEnumerable<Car>>
    { }

    public class GetAllCarsQueryHandler : IHandlerWrapper<GetAllCarsQuery, IEnumerable<Car>>
    {
        public GetAllCarsQueryHandler()
        {
            
        }

        public async Task<Response<IEnumerable<Car>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Car> cars = new []
            {
                new Car { Name = $"Tesla {request.UserId}" },
                new Car { Name = "BMW" }
            };

            return Response.Ok(cars);
        }
    }
}