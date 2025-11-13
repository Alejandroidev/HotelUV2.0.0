using MediatR;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Itineraries.Commands;
using Ardalis.Specification;
using System.Net;
using System;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    public class DeleteItineraryHandler : IRequestHandler<DeleteItineraryCommand, CustomWebResponse>
    {
        private readonly IRepository<Itinerary> _repo;

        public DeleteItineraryHandler(IRepository<Itinerary> repo)
        {
            _repo = repo;
        }

        public async Task<CustomWebResponse> Handle(DeleteItineraryCommand request, CancellationToken cancellationToken)
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

            await _repo.DeleteAsync(entity, cancellationToken);
            return new CustomWebResponse
            {
                ResponseBody = request.Id
            };
        }

        private sealed class ItineraryByIdSpec : Specification<Itinerary>
        {
            public ItineraryByIdSpec(Guid id)
            {
                Query.Where(i => i.Id == id);
            }
        }
    }
}