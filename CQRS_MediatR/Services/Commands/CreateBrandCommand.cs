using System;
using System.Threading;
using System.Threading.Tasks;
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
        public CreateBrandCommandHandler(EntityContext context)
        {
            _db = context;
        }
        public async Task<Response<BrandDetail>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var newBrand = new Brand
            {
                Name = request.Name,
                CreatedBy = request.UserId,
                CreatedAt = request.RequestedAt,
                UpdatedBy = request.UserId,
                UpdatedAt = request.RequestedAt
            };

            _db.Brands.Add(newBrand);
            await _db.SaveChangesAsync();
            
            return Response.Ok<BrandDetail>(null, "Brand created!");
        }
    }
}