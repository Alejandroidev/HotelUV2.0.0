using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Rooms.Commands;
using ReservaHotel.Application.Rooms.Queries;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    /// <summary>
    /// Manages Room resources.
    /// </summary>
    /// <remarks>
    /// Example: create a room
    /// POST /rooms
    /// { "name": "101", "description": "City view", "price": 150000, "capacity": 2, "isFeatured": true, "typeRoomId": "{guid}", "locationId": "{guid}" }
    /// </remarks>
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of <see cref="RoomsController"/>.
        /// </summary>
        public RoomsController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a room by identifier.
        /// </summary>
        /// <param name="id">Room identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Room details if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetRoomByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Lists all rooms.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Collection of rooms.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetRoomsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Creates a new room.
        /// </summary>
        /// <param name="dto">Room payload.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Created room.</returns>
        /// <remarks>
        /// Example:
        /// try { var res = await _mediator.Send(new CreateRoomCommand(dto), ct); } catch (Exception ex) { /* log */ }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateRoomCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Updates an existing room.
        /// </summary>
        /// <param name="id">Room identifier.</param>
        /// <param name="dto">Updated payload.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Updated room or 404.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] RoomDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateRoomCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Deletes an existing room.
        /// </summary>
        /// <param name="id">Room identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Deleted identifier or 404.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteRoomCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}
