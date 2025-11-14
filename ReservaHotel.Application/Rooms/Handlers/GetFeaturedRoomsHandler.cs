using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Queries;
using ReservaHotel.Application.Rooms.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Handlers
{
    /// <summary>
    /// Handles requests to list featured/non-featured rooms.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetFeaturedRoomsQuery(true), ct);
    /// </remarks>
    public class GetFeaturedRoomsHandler : IRequestHandler<GetFeaturedRoomsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Room> _repo;
        private readonly IMapper _mapper;

        public GetFeaturedRoomsHandler(IReadRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
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