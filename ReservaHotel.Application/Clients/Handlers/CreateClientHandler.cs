using AutoMapper;
using MediatR;
using ReservaHotel.Application.Clients.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Clients.Handlers
{
    /// <summary>
    /// Handles client creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateClientCommand(dto), ct); } catch (Exception ex) { /* log */ }
    /// </summary>
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, CustomWebResponse>
    {
        private readonly IRepository<Client> _repo;
        private readonly IMapper _mapper;

        public CreateClientHandler(IRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateClientCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Client>(request.Client);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.ClientDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the client."
                };
            }
        }
    }
}