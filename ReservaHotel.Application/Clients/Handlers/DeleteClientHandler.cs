using MediatR;
using ReservaHotel.Application.Clients.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Clients.Handlers
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, CustomWebResponse>
    {
        private readonly IRepository<Client> _repo;

        public DeleteClientHandler(IRepository<Client> repo)
        {
            _repo = repo;
        }

        public async Task<CustomWebResponse> Handle(DeleteClientCommand request, CancellationToken ct)
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

            await _repo.DeleteAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = request.Id
            };
        }
    }
}