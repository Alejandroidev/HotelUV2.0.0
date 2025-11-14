using MediatR;
using ReservaHotel.Application.Locations.Commands;
using ReservaHotel.Application.Locations.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Locations.Handlers
{
    /// <summary>
    /// Handles location deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteLocationCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, CustomWebResponse>
    {
        private readonly IRepository<Location> _repo;

        public DeleteLocationHandler(IRepository<Location> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteLocationCommand request, CancellationToken ct)
        {
            try
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
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while deleting the location."
                };
            }
        }
    }
}