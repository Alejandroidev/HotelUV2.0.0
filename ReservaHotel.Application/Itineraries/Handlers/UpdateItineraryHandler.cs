using AutoMapper;
using MediatR;
using ReservaHotel.Application.Itineraries.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Itineraries.Handlers
{
    /// <summary>
    /// Handles itinerary update requests.
    /// Example:
    /// try { var res = await _mediator.Send(new UpdateItineraryCommand(id, dto), ct); } catch { /* log */ }
    /// </summary>
    public class UpdateItineraryHandler : IRequestHandler<UpdateItineraryCommand, CustomWebResponse>
    {
        private readonly IRepository<Itinerary> _repo;
        private readonly IMapper _mapper;

        public UpdateItineraryHandler(IRepository<Itinerary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateItineraryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var spec = new ItinerarySpec(request.Id);
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
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the itinerary."
                };
            }
        }
    }
}