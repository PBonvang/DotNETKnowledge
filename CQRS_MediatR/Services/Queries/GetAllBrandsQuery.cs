using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DataAccess;
using Services.Models;
using Services.Wrappers;
using AutoMapper;

namespace Services.Queries
{
    public class GetAllBrandsQuery : BaseRequest, IRequestWrapper<IEnumerable<BrandOverview>>
    { }

    public class GetAllBrandsQueryHandler : IHandlerWrapper<GetAllBrandsQuery, IEnumerable<BrandOverview>>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        
        public GetAllBrandsQueryHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<Response<IEnumerable<BrandOverview>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<BrandOverview> brands = _db.Brands
                .Select(_mapper.Map<BrandOverview>).ToList();

            return Response.Ok(brands);
        }
    }
}