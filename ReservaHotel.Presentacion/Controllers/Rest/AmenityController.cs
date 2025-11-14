using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Amenities.Queries;
using ReservaHotel.Application.Amenities.Commands;
using ReservaHotel.Application.Common.Dtos;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    /// <summary>
    /// Manages Amenity resources.
    /// </summary>
    [ApiController]
    [Route("amenity")]
    public class AmenityController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of <see cref="AmenityController"/>.
        /// </summary>
        public AmenityController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all amenities.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>List of amenities.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetAmenitiesQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Returns an amenity by id.
        /// </summary>
        /// <param name="id">Amenity identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Amenity details.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetAmenityByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Creates a new amenity.
        /// </summary>
        /// <param name="dto">Amenity payload.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The created amenity.</returns>
        /// <remarks>
        /// Example:
        /// try { var res = await _mediator.Send(new CreateAmenityCommand(dto), ct); } catch { /* log */ }
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AmenityDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateAmenityCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Updates an existing amenity.
        /// </summary>
        /// <param name="id">Amenity identifier.</param>
        /// <param name="dto">Updated payload.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The updated amenity.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] AmenityDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateAmenityCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Deletes an amenity.
        /// </summary>
        /// <param name="id">Amenity identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The deleted id.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteAmenityCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}