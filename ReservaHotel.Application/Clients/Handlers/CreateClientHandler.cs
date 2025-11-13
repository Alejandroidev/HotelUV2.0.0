using AutoMapper;
using MediatR;
using ReservaHotel.Application.Clients.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Clients.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, CustomWebResponse>
    {
        private readonly IRepository<Client> _repo;
        private readonly IMapper _mapper;

        public CreateClientHandler(IRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateClientCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Client>(request.Client);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.ClientDto>(entity)
            };
        }
    }
}