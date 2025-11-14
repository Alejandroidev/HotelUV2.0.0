using AutoMapper;
using MediatR;
using ReservaHotel.Application.CustomerInteractions.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.CustomerInteractions.Handlers
{
    /// <summary>
    /// Handles requests to list all customer interactions.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetCustomerInteractionsQuery(), ct);
    /// </remarks>
    public class GetCustomerInteractionsHandler : IRequestHandler<GetCustomerInteractionsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<CustomerInteraction> _repo;
        private readonly IMapper _mapper;

        public GetCustomerInteractionsHandler(IReadRepository<CustomerInteraction> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetCustomerInteractionsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.CustomerInteractionDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}