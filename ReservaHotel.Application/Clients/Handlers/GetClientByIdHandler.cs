using AutoMapper;
using MediatR;
using ReservaHotel.Application.Clients.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Clients.Handlers
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Client> _repo;
        private readonly IMapper _mapper;

        public GetClientByIdHandler(IReadRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetClientByIdQuery request, CancellationToken ct)
        {
            var spec = new ClientSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Client not found"
                };
            }

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.ClientDto>(entity)
            };
        }
    }
}