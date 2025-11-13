using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Queries;
using ReservaHotel.Application.Rooms.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Handlers
{
    public class GetFeaturedRoomsHandler : IRequestHandler<GetFeaturedRoomsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Room> _repo;
        private readonly IMapper _mapper;

        public GetFeaturedRoomsHandler(IReadRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetFeaturedRoomsQuery request, CancellationToken ct)
        {
            var spec = new FeaturedRoomsSpec(request.IsFeatured);
            var list = await _repo.ListAsync(spec, ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.RoomDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}