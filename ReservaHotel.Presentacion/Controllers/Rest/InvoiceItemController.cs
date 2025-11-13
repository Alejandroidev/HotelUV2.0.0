using Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.InvoiceItems.Queries;
using ReservaHotel.Application.InvoiceItems.Commands;
using ReservaHotel.Application.Common.Dtos;
using System;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("invoice-item")]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IMediator _mediator;

        public InvoiceItemController(IWebTools webTools, IMediator mediator)
        {
            _webTools = webTools;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _mediator.Send(new GetInvoiceItemsQuery(), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetInvoiceItemByIdQuery(id), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceItemDto dto, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateInvoiceItemCommand(dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] InvoiceItemDto dto, CancellationToken ct)
        {
            dto.Id = id;
            var response = await _mediator.Send(new UpdateInvoiceItemCommand(id, dto), ct);
            return _webTools.CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteInvoiceItemCommand(id), ct);
            return _webTools.CustomResponse(response);
        }
    }
}