using AutoMapper;
using MediatR;
using ReservaHotel.Application.StatusBookings.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.StatusBookings.Handlers
{
    /// <summary>
    /// Handles booking status creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateStatusBookingCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateStatusBookingHandler : IRequestHandler<CreateStatusBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<StatusBooking> _repo;
        private readonly IMapper _mapper;

        public CreateStatusBookingHandler(IRepository<StatusBooking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateStatusBookingCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<StatusBooking>(request.StatusBooking);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.StatusBookingDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the booking status."
                };
            }
        }
    }
}