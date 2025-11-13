using AutoMapper;
using MediatR;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Itineraries.Commands;
using Ardalis.Specification;
using System.Net;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    public class UpdateItineraryHandler : IRequestHandler<UpdateItineraryCommand, CustomWebResponse>
    {
        private readonly IRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public UpdateItineraryHandler(IRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(UpdateItineraryCommand request, CancellationToken cancellationToken)
        {
            var spec = new ItineraryByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, cancellationToken);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Itinerary not found"
                };
            }

            _mapper.Map(request.Itinerary, entity);
            await _repo.UpdateAsync(entity, cancellationToken);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.ItineraryDto>(entity)
            };
        }

        private sealed class ItineraryByIdSpec : Specification<Itinerary>
        {
            public ItineraryByIdSpec(int id)
            {
                Query.Where(i => i.Id == id);
            }
        }
    }
}