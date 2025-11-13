using AutoMapper;
using MediatR;
using ReservaHotel.Application.Clients.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Clients.Handlers
{
    public class GetClientsHandler : IRequestHandler<GetClientsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Client> _repo;
        private readonly IMapper _mapper;

        public GetClientsHandler(IReadRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetClientsQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.ClientDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}