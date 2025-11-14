using AutoMapper;
using MediatR;
using ReservaHotel.Application.Itineraries.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    /// <summary>
    /// Handles itinerary creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateItineraryCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateItineraryHandler : IRequestHandler<CreateItineraryCommand, CustomWebResponse>
    {
        private readonly IRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public CreateItineraryHandler(IRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateItineraryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Itinerary>(request.Itinerary);
                await _repo.AddAsync(entity, cancellationToken);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.ItineraryDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the itinerary."
                };
            }
        }
    }
}