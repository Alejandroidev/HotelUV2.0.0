using AutoMapper;
using MediatR;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Itineraries.Queries;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    public class GetItinerariesHandler : IRequestHandler<GetItinerariesQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public GetItinerariesHandler(IReadRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

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