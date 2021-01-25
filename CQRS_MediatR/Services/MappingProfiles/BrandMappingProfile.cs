using AutoMapper;
using DataAccess.Entities;
using Services.Commands;
using Services.Models;

namespace Services.MappingProfiles
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDetail>();
            CreateMap<Brand, BrandOverview>();

            CreateMap<CreateBrandCommand, Brand>()
                .ConstructUsing(src => new Brand
                {
                    Name = src.Name,
                    CreatedBy = src.UserId,
                    CreatedAt = src.RequestedAt,
                    UpdatedBy = src.UserId,
                    UpdatedAt = src.RequestedAt
                });
                
            CreateMap<Brand, string>()
                .ConstructUsing(src => src.Name);
        }
    }
}