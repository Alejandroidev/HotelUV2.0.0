using AutoMapper;
using MediatR;
using ReservaHotel.Application.Amenities.Queries;
using ReservaHotel.Application.Amenities.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Amenities.Handlers
{
    public class GetAmenityByIdHandler : IRequestHandler<GetAmenityByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Amenity> _repo;
        private readonly IMapper _mapper;

        public GetAmenityByIdHandler(IReadRepository<Amenity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetAmenityByIdQuery request, CancellationToken ct)
        {
            var spec = new AmenityByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Amenity not found"
                };
            }

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.AmenityDto>(entity)
            };
        }
    }
}