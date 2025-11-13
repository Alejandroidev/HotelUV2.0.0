using AutoMapper;
using MediatR;
using ReservaHotel.Application.Bookings.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Bookings.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<Booking> _repo;
        private readonly IMapper _mapper;

        public CreateBookingHandler(IRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateBookingCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Booking>(request.Booking);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.BookingDto>(entity)
            };
        }
    }
}