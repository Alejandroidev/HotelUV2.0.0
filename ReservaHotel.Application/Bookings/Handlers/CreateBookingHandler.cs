using AutoMapper;
using MediatR;
using ReservaHotel.Application.Bookings.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Bookings.Handlers
{
    /// <summary>
    /// Handles CreateBookingCommand requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateBookingCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<Booking> _repo;
        private readonly IMapper _mapper;

        public CreateBookingHandler(IRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateBookingCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Booking>(request.Booking);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.BookingDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the booking."
                };
            }
        }
    }
}