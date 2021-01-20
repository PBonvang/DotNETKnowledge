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
            CreateMap<BrandDetail, Brand>();

            CreateMap<CreateBrandCommand, Brand>();
        }
    }
}