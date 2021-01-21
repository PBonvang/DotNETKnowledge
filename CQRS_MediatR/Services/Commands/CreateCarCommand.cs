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
    public class CreateCarCommand : BaseRequest, IRequestWrapper<Guid>
    {
        public string Model { get; set; }
        public Guid BrandId { get; set; }
    }

    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, Guid>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        public CreateCarCommandHandler(EntityContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<Guid>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Car>(request);
            await _db.Cars.AddAsync(entity);

            return Response.Ok<Guid>(entity.Id, "Car created!");
        }
    }
}