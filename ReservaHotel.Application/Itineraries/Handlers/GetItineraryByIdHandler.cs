using Ardalis.Specification;
using AutoMapper;
using MediatR;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Itineraries.Queries;
using System.Net;
using System;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    public class GetItineraryByIdHandler : IRequestHandler<GetItineraryByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public GetItineraryByIdHandler(IReadRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetItineraryByIdQuery request, CancellationToken cancellationToken)
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

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.ItineraryDto>(entity)
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