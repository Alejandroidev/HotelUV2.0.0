using AutoMapper;
using MediatR;
using ReservaHotel.Application.Bookings.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Bookings.Handlers
{
    public class GetBookingsHandler : IRequestHandler<GetBookingsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Booking> _repo;
        private readonly IMapper _mapper;

        public GetBookingsHandler(IReadRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

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