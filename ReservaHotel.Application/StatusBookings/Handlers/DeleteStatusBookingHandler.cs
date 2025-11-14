using MediatR;
using ReservaHotel.Application.StatusBookings.Commands;
using ReservaHotel.Application.StatusBookings.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.StatusBookings.Handlers
{
    /// <summary>
    /// Handles booking status deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteStatusBookingCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteStatusBookingHandler : IRequestHandler<DeleteStatusBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<StatusBooking> _repo;

        public DeleteStatusBookingHandler(IRepository<StatusBooking> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteStatusBookingCommand request, CancellationToken ct)
        {
            try
            {
                var spec = new StatusBookingByIdSpec(request.Id);
                var entity = await _repo.FirstOrDefaultAsync(spec, ct);
                if (entity == null)
                {
                    return new CustomWebResponse(true)
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "StatusBooking not found"
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
                    Message = "An unexpected error occurred while deleting the booking status."
                };
            }
        }
    }
}