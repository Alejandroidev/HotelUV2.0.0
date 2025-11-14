using AutoMapper;
using MediatR;
using ReservaHotel.Application.StatusBookings.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.StatusBookings.Handlers
{
    /// <summary>
    /// Handles requests to list all booking statuses.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetStatusBookingsQuery(), ct);
    /// </remarks>
    public class GetStatusBookingsHandler : IRequestHandler<GetStatusBookingsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<StatusBooking> _repo;
        private readonly IMapper _mapper;

        public GetStatusBookingsHandler(IReadRepository<StatusBooking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetStatusBookingsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.StatusBookingDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}