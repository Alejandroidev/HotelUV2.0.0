using AutoMapper;
using MediatR;
using ReservaHotel.Application.Bookings.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Bookings.Handlers
{
    /// <summary>
    /// Handles requests to list all bookings.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetBookingsQuery(), ct);
    /// </remarks>
    public class GetBookingsHandler : IRequestHandler<GetBookingsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Booking> _repo;
        private readonly IMapper _mapper;

        public GetBookingsHandler(IReadRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetBookingsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.BookingDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}