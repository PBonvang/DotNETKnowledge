using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands;
using Services.Models;
using Services.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarOverview>>> GetAllCars()
        {
            var cars = await _mediator.Send(new GetAllCarsQuery());
            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] CreateCarCommand command)
        {
            var newId = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetAllCars), 
                new {Id = newId}
            );
        }
    }
}
