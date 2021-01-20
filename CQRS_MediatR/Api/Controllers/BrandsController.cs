using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands;
using Services.Models;
using Services.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BrandsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandOverview>> GetAllBrands()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
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
