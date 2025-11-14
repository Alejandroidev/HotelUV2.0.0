using AutoMapper;
using MediatR;
using ReservaHotel.Application.Bookings.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications.Hotel;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Bookings.Handlers
{
    /// <summary>
    /// Handles requests to retrieve a booking by its identifier.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetBookingByIdQuery(id), ct);
    /// </remarks>
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Booking> _repo;
        private readonly IMapper _mapper;

        public GetBookingByIdHandler(IReadRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetBookingByIdQuery request, CancellationToken ct)
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

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.BookingDto>(entity)
            };
        }
    }
}