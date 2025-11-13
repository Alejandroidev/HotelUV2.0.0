using MediatR;
using ReservaHotel.Application.InvoiceItems.Commands;
using ReservaHotel.Application.InvoiceItems.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.InvoiceItems.Handlers
{
    public class DeleteInvoiceItemHandler : IRequestHandler<DeleteInvoiceItemCommand, CustomWebResponse>
    {
        private readonly IRepository<InvoiceItem> _repo;

        public DeleteInvoiceItemHandler(IRepository<InvoiceItem> repo)
        {
            _repo = repo;
        }

        public async Task<CustomWebResponse> Handle(DeleteInvoiceItemCommand request, CancellationToken ct)
        {
            var spec = new InvoiceItemByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "InvoiceItem not found"
                };
            }

            await _repo.DeleteAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = request.Id
            };
        }
    }
}