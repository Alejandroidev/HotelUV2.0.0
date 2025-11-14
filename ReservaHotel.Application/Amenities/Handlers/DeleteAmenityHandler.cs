using MediatR;
using ReservaHotel.Application.Amenities.Commands;
using ReservaHotel.Application.Amenities.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Amenities.Handlers
{
    /// <summary>
    /// Handles amenity deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteAmenityCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteAmenityHandler : IRequestHandler<DeleteAmenityCommand, CustomWebResponse>
    {
        private readonly IRepository<Amenity> _repo;

        public DeleteAmenityHandler(IRepository<Amenity> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteAmenityCommand request, CancellationToken ct)
        {
            try
            {
                var spec = new AmenityByIdSpec(request.Id);
                var entity = await _repo.FirstOrDefaultAsync(spec, ct);
                if (entity == null)
                {
                    return new CustomWebResponse(true)
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Amenity not found"
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
                    Message = "An unexpected error occurred while deleting the amenity."
                };
            }
        }
    }
}