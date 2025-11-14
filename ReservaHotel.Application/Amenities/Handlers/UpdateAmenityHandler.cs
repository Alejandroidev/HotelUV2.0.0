using AutoMapper;
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
    /// Handles amenity update requests.
    /// Example:
    /// try { var res = await _mediator.Send(new UpdateAmenityCommand(id, dto), ct); } catch { /* log */ }
    /// </summary>
    public class UpdateAmenityHandler : IRequestHandler<UpdateAmenityCommand, CustomWebResponse>
    {
        private readonly IRepository<Amenity> _repo;
        private readonly IMapper _mapper;

        public UpdateAmenityHandler(IRepository<Amenity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateAmenityCommand request, CancellationToken ct)
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

                _mapper.Map(request.Amenity, entity);
                await _repo.UpdateAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = _mapper.Map<Application.Common.Dtos.AmenityDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the amenity."
                };
            }
        }
    }
}