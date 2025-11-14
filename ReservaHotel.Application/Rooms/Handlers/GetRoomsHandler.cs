using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Handlers
{
    /// <summary>
    /// Handles requests to list all rooms.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetRoomsQuery(), ct);
    /// </remarks>
    public class GetRoomsHandler : IRequestHandler<GetRoomsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Room> _repo;
        private readonly IMapper _mapper;

        public GetRoomsHandler(IReadRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
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