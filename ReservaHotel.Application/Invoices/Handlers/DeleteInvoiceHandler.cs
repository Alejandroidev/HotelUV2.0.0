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
    /// Handles invoice deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteInvoiceCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand, CustomWebResponse>
    {
        private readonly IRepository<Invoice> _repo;

        public DeleteInvoiceHandler(IRepository<Invoice> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteInvoiceCommand request, CancellationToken ct)
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

                await _repo.DeleteAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = request.Id
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while deleting the invoice."
                };
            }
        }
    }
}