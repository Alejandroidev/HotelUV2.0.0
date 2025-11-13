using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Rooms.Commands;
using ReservaHotel.Application.Rooms.Queries;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public RoomsController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetRoomByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet("featured")]
        public async Task<IActionResult> GetByFeatured([FromQuery] bool isFeatured, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetFeaturedRoomsQuery(isFeatured), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetRoomsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateRoomCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] RoomDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateRoomCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteRoomCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}
