using AutoMapper;
using MediatR;
using ReservaHotel.Application.Invoices.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Invoices.Handlers
{
    /// <summary>
    /// Handles requests to list all invoices.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetInvoicesQuery(), ct);
    /// </remarks>
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Invoice> _repo;
        private readonly IMapper _mapper;

        public GetInvoicesHandler(IReadRepository<Invoice> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetInvoicesQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.InvoiceDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}