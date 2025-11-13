using MediatR;
using ReservaHotel.Application.StatusBookings.Commands;
using ReservaHotel.Application.StatusBookings.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.StatusBookings.Handlers
{
    public class DeleteStatusBookingHandler : IRequestHandler<DeleteStatusBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<StatusBooking> _repo;

        public DeleteStatusBookingHandler(IRepository<StatusBooking> repo)
        {
            _repo = repo;
        }

        public async Task<CustomWebResponse> Handle(DeleteStatusBookingCommand request, CancellationToken ct)
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
    }
}