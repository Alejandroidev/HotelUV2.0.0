using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Handlers
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, CustomWebResponse>
    {
        private readonly IRepository<Room> _repo;
        private readonly IMapper _mapper;

        public CreateRoomHandler(IRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateRoomCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Room>(request.Room);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.RoomDto>(entity)
            };
        }
    }
}