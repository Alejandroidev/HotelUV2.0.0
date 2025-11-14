using MediatR;
using ReservaHotel.Application.Bookings.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications.Hotel;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Bookings.Handlers
{
    /// <summary>
    /// Handles booking deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteBookingCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<Booking> _repo;

        public DeleteBookingHandler(IRepository<Booking> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteBookingCommand request, CancellationToken ct)
        {
            try
            {
                var spec = new BookingSpec(request.Id);
                var entity = await _repo.FirstOrDefaultAsync(spec, ct);
                if (entity == null)
                {
                    return new CustomWebResponse(true)
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Booking not found"
                    };
                }

                await _repo.DeleteAsync(entity, ct);
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
                    Message = "An unexpected error occurred while deleting the booking."
                };
            }
        }
    }
}