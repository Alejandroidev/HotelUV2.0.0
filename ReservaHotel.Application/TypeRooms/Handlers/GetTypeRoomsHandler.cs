using AutoMapper;
using MediatR;
using ReservaHotel.Application.TypeRooms.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.TypeRooms.Handlers
{
    /// <summary>
    /// Handles requests to list all room types.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetTypeRoomsQuery(), ct);
    /// </remarks>
    public class GetTypeRoomsHandler : IRequestHandler<GetTypeRoomsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<TypeRoom> _repo;
        private readonly IMapper _mapper;

        public GetTypeRoomsHandler(IReadRepository<TypeRoom> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetTypeRoomsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.TypeRoomDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}