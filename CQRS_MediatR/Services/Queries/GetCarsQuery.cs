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
    public class GetCarsQuery : BaseRequest, IRequestWrapper<IEnumerable<CarOverview>>
    {
        public string ModelQuery { get; set; }
    }

    public class GetAllCarsQueryHandler : IHandlerWrapper<GetCarsQuery, IEnumerable<CarOverview>>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        public GetAllCarsQueryHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CarOverview>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var query = _db.Cars.AsQueryable();
            if (request.ModelQuery != null) 
                query = query.Where(c => c.Model.Contains(request.ModelQuery));

            IEnumerable<CarOverview> cars = query
                .Select(_mapper.Map<CarOverview>).ToList();

            return Response.Ok(cars);
        }
    }
}