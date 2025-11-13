using AutoMapper;
using MediatR;
using ReservaHotel.Application.Locations.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Locations.Handlers
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, CustomWebResponse>
    {
        private readonly IRepository<Location> _repo;
        private readonly IMapper _mapper;

        public CreateLocationHandler(IRepository<Location> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateLocationCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Location>(request.Location);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.LocationDto>(entity)
            };
        }
    }
}