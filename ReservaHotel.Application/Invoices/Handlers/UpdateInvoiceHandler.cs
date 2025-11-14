using AutoMapper;
using MediatR;
using ReservaHotel.Application.Invoices.Commands;
using ReservaHotel.Application.Invoices.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Invoices.Handlers
{
    /// <summary>
    /// Handles invoice update requests.
    /// Example:
    /// try { var res = await _mediator.Send(new UpdateInvoiceCommand(id, dto), ct); } catch { /* log */ }
    /// </summary>
    public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, CustomWebResponse>
    {
        private readonly IRepository<Invoice> _repo;
        private readonly IMapper _mapper;

        public UpdateInvoiceHandler(IRepository<Invoice> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateInvoiceCommand request, CancellationToken ct)
        {
            try
            {
                var spec = new InvoiceByIdSpec(request.Id);
                var entity = await _repo.FirstOrDefaultAsync(spec, ct);
                if (entity == null)
                {
                    return new CustomWebResponse(true)
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Invoice not found"
                    };
                }

                _mapper.Map(request.Invoice, entity);
                await _repo.UpdateAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = _mapper.Map<Application.Common.Dtos.InvoiceDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the invoice."
                };
            }
        }
    }
}