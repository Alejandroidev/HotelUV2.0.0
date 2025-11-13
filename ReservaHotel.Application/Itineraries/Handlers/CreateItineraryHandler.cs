using AutoMapper;
using MediatR;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Itineraries.Commands;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    public class CreateItineraryHandler : IRequestHandler<CreateItineraryCommand, CustomWebResponse>
    {
        private readonly IRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public CreateItineraryHandler(IRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateItineraryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Itinerary>(request.Itinerary);
            await _repo.AddAsync(entity, cancellationToken);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.ItineraryDto>(entity)
            };
        }
    }
}