using AutoMapper;
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
    /// Handles location update requests.
    /// Example:
    /// try { var res = await _mediator.Send(new UpdateLocationCommand(id, dto), ct); } catch { /* log */ }
    /// </summary>
    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, CustomWebResponse>
    {
        private readonly IRepository<Location> _repo;
        private readonly IMapper _mapper;

        public UpdateLocationHandler(IRepository<Location> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateLocationCommand request, CancellationToken ct)
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

                _mapper.Map(request.Location, entity);
                await _repo.UpdateAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = _mapper.Map<Application.Common.Dtos.LocationDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the location."
                };
            }
        }
    }
}