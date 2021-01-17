using System;
using System.Threading;
using System.Threading.Tasks;
using Services.Models;
using Services.Wrappers;

namespace Services.Commands
{
    public class CreateCarCommand : BaseRequest, IRequestWrapper<Car>
    {
        public string Name { get; set; }
    }

    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, Car>
    {
        public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            //Simulation of failure
            if (false) return Task.FromResult(Response.Fail<Car>("Already exists"));

            var newCar = new Car
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name
            };

            return Task.FromResult(
                Response.Ok<Car>(newCar, "Car created!"));
        }
    }
}