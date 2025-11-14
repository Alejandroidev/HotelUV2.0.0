using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Bookings.Commands;
using ReservaHotel.Application.Bookings.Queries;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    /// <summary>
    /// Manages Booking resources (create, read, update, delete).
    /// </summary>
    /// <remarks>
    /// Example create:
    /// POST /booking
    /// { "checkInDate":"2025-02-01", "checkOutDate":"2025-02-05", "numberOfGuests":2, "totalPrice":600000, "clientId":"{guid}", "roomId":"{guid}", "statusBookingId":"{guid}" }
    /// </remarks>
    [ApiController]
    [Route("booking")]
    public class BookingController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of <see cref="BookingController"/>.
        /// </summary>
        public BookingController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a booking by identifier.
        /// </summary>
        /// <param name="id">Booking identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Booking data or 404.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetBookingByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Lists all bookings.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Collection of bookings.</returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetBookingsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="dto">Booking payload.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The created booking.</returns>
        /// <remarks>
        /// Usage:
        /// try { var result = await _mediator.Send(new CreateBookingCommand(dto), ct); } catch (Exception ex) { /* log */ }
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] BookingDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateBookingCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Updates an existing booking.
        /// </summary>
        /// <param name="id">Booking identifier.</param>
        /// <param name="dto">Updated booking payload.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Updated booking or 404.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] BookingDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateBookingCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Deletes a booking.
        /// </summary>
        /// <param name="id">Booking identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Deleted identifier or 404.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteBookingCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}