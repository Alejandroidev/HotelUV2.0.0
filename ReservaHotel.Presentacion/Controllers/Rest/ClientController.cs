using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Clients.Commands;
using ReservaHotel.Application.Clients.Queries;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public ClientController(IWebTools webTools, IMediator mediator)
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
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetClientByIdQuery(id), ct);
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
            var response = await _mediator.Send(new GetClientsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="clientDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateClientCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="clientDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ClientDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateClientCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Delete Client
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteClientCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}
