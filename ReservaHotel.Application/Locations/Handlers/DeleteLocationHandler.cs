using MediatR;
using ReservaHotel.Application.Locations.Commands;
using ReservaHotel.Application.Locations.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Locations.Handlers
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, CustomWebResponse>
    {
        private readonly IRepository<Location> _repo;

        public DeleteLocationHandler(IRepository<Location> repo)
        {
            _repo = repo;
        }

        public async Task<CustomWebResponse> Handle(DeleteLocationCommand request, CancellationToken ct)
        {
            var spec = new LocationByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Location not found"
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