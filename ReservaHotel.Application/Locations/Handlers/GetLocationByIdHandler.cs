using AutoMapper;
using MediatR;
using ReservaHotel.Application.Locations.Queries;
using ReservaHotel.Application.Locations.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Locations.Handlers
{
    public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Location> _repo;
        private readonly IMapper _mapper;

        public GetLocationByIdHandler(IReadRepository<Location> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetLocationByIdQuery request, CancellationToken ct)
        {
            var spec = new LocationByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Location not found"
                };
            }

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.LocationDto>(entity)
            };
        }
    }
}