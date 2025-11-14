using AutoMapper;
using MediatR;
using ReservaHotel.Application.InvoiceItems.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.InvoiceItems.Handlers
{
    /// <summary>
    /// Handles invoice item creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateInvoiceItemCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateInvoiceItemHandler : IRequestHandler<CreateInvoiceItemCommand, CustomWebResponse>
    {
        private readonly IRepository<InvoiceItem> _repo;
        private readonly IMapper _mapper;

        public CreateInvoiceItemHandler(IRepository<InvoiceItem> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateInvoiceItemCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<InvoiceItem>(request.InvoiceItem);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.InvoiceItemDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the invoice item."
                };
            }
        }
    }
}