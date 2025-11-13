using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Amenities.Queries;

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
    }
}