using AutoMapper;
using MediatR;
using ReservaHotel.Application.Clients.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Clients.Handlers
{
    /// <summary>
    /// Handles requests to list all clients.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetClientsQuery(), ct);
    /// </remarks>
    public class GetClientsHandler : IRequestHandler<GetClientsQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Client> _repo;
        private readonly IMapper _mapper;

        public GetClientsHandler(IReadRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
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