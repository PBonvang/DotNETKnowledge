using System;
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
        public async Task<ActionResult<IEnumerable<BrandOverview>>> GetAllBrands()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BrandDetail>> GetBrand(Guid id)
        {
            var query = new GetBrandQuery
            {
                Id = id
            };

            var brand = await _mediator.Send(query);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand([FromBody] CreateBrandCommand command)
        {
            var newId = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetAllBrands), 
                new {Id = newId}
            );
        }
    }
}
