using System;
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
            var response = await _mediator.Send(new GetAllCarsQuery());

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CarDetail>> GetCar(Guid id)
        {
            var query = new GetCarQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);
            if (response.Error) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] CreateCarCommand command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetCar),
                new {id = response.Data.Id},
                response
            );
        }
    }
}
