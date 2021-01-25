using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Wrappers;
using AutoMapper;
using System;
using DataAccess.Entities;

namespace Services.Queries
{
    public class GetBrandQuery : BaseRequest, IRequestWrapper<BrandDetail>
    { 
        public Guid Id { get; set; }
    }

    public class GetBrandQueryHandler : IHandlerWrapper<GetBrandQuery, BrandDetail>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        
        public GetBrandQueryHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<Response<BrandDetail>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            Brand entity = await _db.Brands
                .Include(b => b.Cars)
                .FirstOrDefaultAsync(b => b.Id == request.Id);
                
            if (entity == null) return Response.Fail<BrandDetail>("No brand found");
            
            BrandDetail brand = _mapper.Map<BrandDetail>(entity);

            return Response.Ok(brand);
        }
    }
}