using AutoMapper;
using MediatR;
using ReservaHotel.Application.Amenities.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Amenities.Handlers
{
    /// <summary>
    /// Handles requests to list all amenities.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetAmenitiesQuery(), ct);
    /// </remarks>
    public class GetAmenitiesHandler : IRequestHandler<GetAmenitiesQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Amenity> _repo;
        private readonly IMapper _mapper;

        public GetAmenitiesHandler(IReadRepository<Amenity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetAmenitiesQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.AmenityDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}