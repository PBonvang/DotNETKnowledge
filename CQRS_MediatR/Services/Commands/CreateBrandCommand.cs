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
    public class CreateBrandCommand : BaseRequest, IRequestWrapper<BrandDetail>
    {
        public string Name { get; set; }
    }

    public class CreateBrandCommandHandler : IHandlerWrapper<CreateBrandCommand, BrandDetail>
    {
        private readonly EntityContext _db;
        private readonly IMapper _mapper;
        public CreateBrandCommandHandler(EntityContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<Response<BrandDetail>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var newBrand = _mapper.Map<Brand>(request);

            _db.Brands.Add(newBrand);
            await _db.SaveChangesAsync();
            
            return Response.Ok<BrandDetail>(null, "Brand created!");
        }
    }
}