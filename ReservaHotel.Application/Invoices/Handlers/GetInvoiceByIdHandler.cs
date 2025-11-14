using AutoMapper;
using MediatR;
using ReservaHotel.Application.Invoices.Queries;
using ReservaHotel.Application.Invoices.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Invoices.Handlers
{
    /// <summary>
    /// Handles requests to retrieve an invoice by identifier.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetInvoiceByIdQuery(id), ct);
    /// </remarks>
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Invoice> _repo;
        private readonly IMapper _mapper;

        public GetInvoiceByIdHandler(IReadRepository<Invoice> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetInvoiceByIdQuery request, CancellationToken ct)
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
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.InvoiceDto>(entity)
            };
        }
    }
}