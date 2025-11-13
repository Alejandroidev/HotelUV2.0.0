using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Amenities.Queries;
using ReservaHotel.Application.Amenities.Commands;
using ReservaHotel.Application.Common.Dtos;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("amenity")]
    public class AmenityController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public AmenityController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetAmenitiesQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetAmenityByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AmenityDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateAmenityCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AmenityDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateAmenityCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteAmenityCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}