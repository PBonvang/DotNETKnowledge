using System;
using System.Threading;
using System.Threading.Tasks;
using Services.Models;
using Services.Wrappers;

namespace Services.Commands
{
    public class CreateCarCommand : BaseRequest, IRequestWrapper<CarDetail>
    {
        public string Name { get; set; }
    }

    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, CarDetail>
    {
        public Task<Response<CarDetail>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            //Simulation of failure
            if (false) return Task.FromResult(Response.Fail<CarDetail>("Already exists"));

            var newCar = new CarDetail
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            return Task.FromResult(
                Response.Ok<CarDetail>(newCar, "Car created!"));
        }
    }
}