using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Wrappers;

namespace Services.Queries
{
    public class GetCarQuery : BaseRequest, IRequestWrapper<CarDetail>
    { 
        public Guid Id { get; set; }
    }

    public class GetCarQueryHandler : IHandlerWrapper<GetCarQuery, CarDetail>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        public GetCarQueryHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Response<CarDetail>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var entity = await _db.Cars.AsNoTracking()
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (entity == null) return Response.Fail<CarDetail>("No car found");

            var car = _mapper.Map<CarDetail>(entity);

            return Response.Ok(car);
        }
    }
}