using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Domain.Dto;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("client")]
    public class ItineraryController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IItineraryService _entityService;
        public ItineraryController(IWebTools webTools, IItineraryService entityService)
        {
            _webTools = webTools;
            _entityService = entityService;
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
            var response = await _entityService.Get(id, ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Get All entities
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _entityService.GetAll(ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="itineraryDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPost()]
        public async Task<IActionResult> Post(ItineraryDto itineraryDto, CancellationToken ct)
        {
            var response = await _entityService.Add(itineraryDto, ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="itineraryDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPut()]
        public async Task<IActionResult> Put(int id, ItineraryDto itineraryDto, CancellationToken ct)
        {
            var response = await _entityService.Update(id, itineraryDto, ct);
            return _webTools.CustomResponse(response);
        }

    }
}
