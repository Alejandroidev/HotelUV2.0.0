using AutoMapper;
using MediatR;
using ReservaHotel.Application.Itineraries.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    /// <summary>
    /// Handles requests to list all itineraries.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetItinerariesQuery(), ct);
    /// </remarks>
    public class GetItinerariesHandler : IRequestHandler<GetItinerariesQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public GetItinerariesHandler(IReadRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetItinerariesQuery request, CancellationToken cancellationToken)
        {
            var list = await _repo.ListAsync(cancellationToken);
            var dto = _mapper.Map<List<Application.Common.Dtos.ItineraryDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}