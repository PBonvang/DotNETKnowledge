using AutoMapper;
using DataAccess.Entities;
using Services.Commands;
using Services.Models;

namespace Services.MappingProfiles
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, CarDetail>();
            CreateMap<Car, CarOverview>();

            CreateMap<CreateCarCommand, Car>()
                .ConstructUsing(src => new Car
                {
                    Model = src.Model,
                    BrandId = src.BrandId,
                    CreatedBy = src.UserId,
                    CreatedAt = src.RequestedAt,
                    UpdatedBy = src.UserId,
                    UpdatedAt = src.RequestedAt

                });
        }
    }
}