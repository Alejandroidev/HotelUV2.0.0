using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.PqrCases.Queries;
using ReservaHotel.Application.PqrCases.Commands;
using ReservaHotel.Application.Common.Dtos;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("pqr-case")]
    public class PqrCaseController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public PqrCaseController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetPqrCasesQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetPqrCaseByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PqrCaseDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreatePqrCaseCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PqrCaseDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdatePqrCaseCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeletePqrCaseCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}