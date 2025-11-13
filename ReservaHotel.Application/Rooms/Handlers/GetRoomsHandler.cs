using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Handlers
{
    public class GetRoomsHandler : IRequestHandler<GetRoomsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Room> _repo;
        private readonly IMapper _mapper;

        public GetRoomsHandler(IReadRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetRoomsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.RoomDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}