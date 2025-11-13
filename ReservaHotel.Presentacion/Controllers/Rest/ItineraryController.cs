using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Itineraries.Commands;
using ReservaHotel.Application.Itineraries.Queries;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("itinerary")]
    public class ItineraryController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;
        public ItineraryController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetItineraryByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Get All entities
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetItinerariesQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="itineraryDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItineraryDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateItineraryCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="itineraryDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ItineraryDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateItineraryCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Delete entity by identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Result of the delete operation</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteItineraryCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}
