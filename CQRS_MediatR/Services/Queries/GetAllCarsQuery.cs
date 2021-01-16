using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Services.Models;

namespace Services.Queries
{
    public class GetAllCarsQuery : IRequest<IEnumerable<Car>>
    { }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        public GetAllCarsQueryHandler()
        {
            
        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            return new []
            {
                new Car { Name = "Tesla" },
                new Car { Name = "BMW" }
            };
        }
    }
}