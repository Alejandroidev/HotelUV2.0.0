using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.RoomAmenities.Queries;
using ReservaHotel.Application.RoomAmenities.Commands;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("room-amenity")]
    public class RoomAmenityController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public RoomAmenityController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetByRoom(Guid roomId, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetAmenitiesByRoomQuery(roomId), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet("amenity/{amenityId}")]
        public async Task<IActionResult> GetByAmenity(Guid amenityId, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetRoomsByAmenityQuery(amenityId), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] Guid roomId, [FromQuery] Guid amenityId, CancellationToken ct)
        {
            var response = await _mediator.Send(new AddRoomAmenityCommand(roomId, amenityId), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid roomId, [FromQuery] Guid amenityId, CancellationToken ct)
        {
            var response = await _mediator.Send(new RemoveRoomAmenityCommand(roomId, amenityId), ct);
            return _webTools.CustomResponse(response);
        }
    }
}