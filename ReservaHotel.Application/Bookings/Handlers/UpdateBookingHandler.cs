using AutoMapper;
using MediatR;
using ReservaHotel.Application.Bookings.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications.Hotel;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Bookings.Handlers
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<Booking> _repo;
        private readonly IMapper _mapper;

        public UpdateBookingHandler(IRepository<Booking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(UpdateBookingCommand request, CancellationToken ct)
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

            _mapper.Map(request.Booking, entity);
            await _repo.UpdateAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.BookingDto>(entity)
            };
        }
    }
}