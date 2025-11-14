using AutoMapper;
using MediatR;
using ReservaHotel.Application.TypeRooms.Queries;
using ReservaHotel.Application.TypeRooms.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.TypeRooms.Handlers
{
    /// <summary>
    /// Handles requests to retrieve a room type by identifier.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetTypeRoomByIdQuery(id), ct);
    /// </remarks>
    public class GetTypeRoomByIdHandler : IRequestHandler<GetTypeRoomByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<TypeRoom> _repo;
        private readonly IMapper _mapper;

        public GetTypeRoomByIdHandler(IReadRepository<TypeRoom> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetTypeRoomByIdQuery request, CancellationToken ct)
        {
            var spec = new TypeRoomByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "TypeRoom not found"
                };
            }

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.TypeRoomDto>(entity)
            };
        }
    }
}
