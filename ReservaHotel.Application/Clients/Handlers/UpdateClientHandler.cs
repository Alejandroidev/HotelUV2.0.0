using AutoMapper;
using MediatR;
using ReservaHotel.Application.Clients.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Clients.Handlers
{
    /// <summary>
    /// Handles client update requests.
    /// Example:
    /// try { var res = await _mediator.Send(new UpdateClientCommand(id, dto), ct); } catch { /* log */ }
    /// </summary>
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, CustomWebResponse>
    {
        private readonly IRepository<Client> _repo;
        private readonly IMapper _mapper;

        public UpdateClientHandler(IRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateClientCommand request, CancellationToken ct)
        {
            try
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

                _mapper.Map(request.Client, entity);
                await _repo.UpdateAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = _mapper.Map<Application.Common.Dtos.ClientDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the client."
                };
            }
        }
    }
}