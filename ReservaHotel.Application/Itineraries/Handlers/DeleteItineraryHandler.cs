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
    /// Handles itinerary deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteItineraryCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteItineraryHandler : IRequestHandler<DeleteItineraryCommand, CustomWebResponse>
    {
        private readonly IRepository<Itinerary> _repo;

        public DeleteItineraryHandler(IRepository<Itinerary> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteItineraryCommand request, CancellationToken cancellationToken)
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

                await _repo.DeleteAsync(entity, cancellationToken);
                return new CustomWebResponse
                {
                    ResponseBody = request.Id
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while deleting the itinerary."
                };
            }
        }
    }
}