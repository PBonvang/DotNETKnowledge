using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Services.Models;
using Services.Wrappers;

namespace Services.Queries
{
    public class GetAllCarsQuery : BaseRequest, IRequestWrapper<IEnumerable<CarOverview>>
    { }

    public class GetAllCarsQueryHandler : IHandlerWrapper<GetAllCarsQuery, IEnumerable<CarOverview>>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        public GetAllCarsQueryHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CarOverview>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarOverview> cars = _db.Cars
                .Select(_mapper.Map<CarOverview>).ToList();
            
            return Response.Ok(cars);
        }
    }
}