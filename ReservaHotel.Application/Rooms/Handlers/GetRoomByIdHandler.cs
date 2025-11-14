using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Queries;
using ReservaHotel.Application.Rooms.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Rooms.Handlers
{
    /// <summary>
    /// Handles requests to retrieve a room by its identifier.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetRoomByIdQuery(id), ct);
    /// </remarks>
    public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Room> _repo;
        private readonly IMapper _mapper;

        public GetRoomByIdHandler(IReadRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetRoomByIdQuery request, CancellationToken ct)
        {
            var spec = new RoomByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Room not found"
                };
            }

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.RoomDto>(entity)
            };
        }
    }
}