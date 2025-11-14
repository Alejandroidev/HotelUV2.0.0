using AutoMapper;
using MediatR;
using ReservaHotel.Application.StatusBookings.Queries;
using ReservaHotel.Application.StatusBookings.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.StatusBookings.Handlers
{
    /// <summary>
    /// Handles requests to retrieve a booking status by identifier.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetStatusBookingByIdQuery(id), ct);
    /// </remarks>
    public class GetStatusBookingByIdHandler : IRequestHandler<GetStatusBookingByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<StatusBooking> _repo;
        private readonly IMapper _mapper;

        public GetStatusBookingByIdHandler(IReadRepository<StatusBooking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetStatusBookingByIdQuery request, CancellationToken ct)
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

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.StatusBookingDto>(entity)
            };
        }
    }
}