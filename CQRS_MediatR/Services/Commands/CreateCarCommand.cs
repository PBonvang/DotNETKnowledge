using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Services.Models;
using Services.Wrappers;

namespace Services.Commands
{
    public class CreateCarCommand : BaseRequest, IRequestWrapper<CarDetail>
    {
        public string Model { get; set; }
        public Guid BrandId { get; set; }
    }

    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, CarDetail>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        public CreateCarCommandHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<CarDetail>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Car>(request);
            await _db.Cars.AddAsync(entity);

            var newCar = _mapper.Map<CarDetail>(entity);
            if (request.BrandId != null) newCar.Brand = await GetCarBrand(request.BrandId);

            return Response.Ok(newCar, "Car created!");
        }

        private async Task<BrandOverview> GetCarBrand(Guid brandId)
        {
            var entity = await _db.Brands.FindAsync(brandId);
            return _mapper.Map<BrandOverview>(entity);
        }
    }
}