using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Locations.Queries;
using ReservaHotel.Application.Locations.Commands;
using ReservaHotel.Application.Common.Dtos;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("location")]
    public class LocationController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public LocationController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetLocationsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetLocationByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateLocationCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] LocationDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateLocationCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteLocationCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}