using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Clients.Commands;
using ReservaHotel.Application.Clients.Queries;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    /// <summary>
    /// Manages Client resources.
    /// </summary>
    /// <remarks>
    /// Example create:
    /// POST /client
    /// { "name":"Carlos", "lastName":"Rodriguez", "email":"carlos.r@example.com", "phoneNumber":"3101234567" }
    /// </remarks>
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of <see cref="ClientController"/>.
        /// </summary>
        public ClientController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a client by identifier.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetClientByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Lists all clients.
        /// </summary>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetClientsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ClientDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateClientCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ClientDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateClientCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Deletes a client.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteClientCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}
