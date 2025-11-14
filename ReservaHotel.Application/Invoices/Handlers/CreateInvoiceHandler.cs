using AutoMapper;
using MediatR;
using ReservaHotel.Application.Invoices.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Invoices.Handlers
{
    /// <summary>
    /// Handles invoice creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateInvoiceCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, CustomWebResponse>
    {
        private readonly IRepository<Invoice> _repo;
        private readonly IMapper _mapper;

        public CreateInvoiceHandler(IRepository<Invoice> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateInvoiceCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Invoice>(request.Invoice);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.InvoiceDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the invoice."
                };
            }
        }
    }
}