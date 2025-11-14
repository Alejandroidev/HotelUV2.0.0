using AutoMapper;
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
    /// Handles booking status update requests.
    /// Example:
    /// try { var res = await _mediator.Send(new UpdateStatusBookingCommand(id, dto), ct); } catch { /* log */ }
    /// </summary>
    public class UpdateStatusBookingHandler : IRequestHandler<UpdateStatusBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<StatusBooking> _repo;
        private readonly IMapper _mapper;

        public UpdateStatusBookingHandler(IRepository<StatusBooking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateStatusBookingCommand request, CancellationToken ct)
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

                _mapper.Map(request.StatusBooking, entity);
                await _repo.UpdateAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = _mapper.Map<Application.Common.Dtos.StatusBookingDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the booking status."
                };
            }
        }
    }
}