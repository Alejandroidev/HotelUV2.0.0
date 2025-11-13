using AutoMapper;
using MediatR;
using ReservaHotel.Application.Amenities.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Amenities.Handlers
{
    public class CreateAmenityHandler : IRequestHandler<CreateAmenityCommand, CustomWebResponse>
    {
        private readonly IRepository<Amenity> _repo;
        private readonly IMapper _mapper;

        public CreateAmenityHandler(IRepository<Amenity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateAmenityCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Amenity>(request.Amenity);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.AmenityDto>(entity)
            };
        }
    }
}