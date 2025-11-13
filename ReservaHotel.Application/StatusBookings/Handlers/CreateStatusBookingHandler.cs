using AutoMapper;
using MediatR;
using ReservaHotel.Application.StatusBookings.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.StatusBookings.Handlers
{
    public class CreateStatusBookingHandler : IRequestHandler<CreateStatusBookingCommand, CustomWebResponse>
    {
        private readonly IRepository<StatusBooking> _repo;
        private readonly IMapper _mapper;

        public CreateStatusBookingHandler(IRepository<StatusBooking> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateStatusBookingCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<StatusBooking>(request.StatusBooking);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.StatusBookingDto>(entity)
            };
        }
    }
}