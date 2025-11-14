using AutoMapper;
using MediatR;
using ReservaHotel.Application.InvoiceItems.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.InvoiceItems.Handlers
{
    /// <summary>
    /// Handles requests to list all invoice items.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetInvoiceItemsQuery(), ct);
    /// </remarks>
    public class GetInvoiceItemsHandler : IRequestHandler<GetInvoiceItemsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<InvoiceItem> _repo;
        private readonly IMapper _mapper;

        public GetInvoiceItemsHandler(IReadRepository<InvoiceItem> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetInvoiceItemsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.InvoiceItemDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}