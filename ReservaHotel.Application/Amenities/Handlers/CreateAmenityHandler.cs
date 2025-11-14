using AutoMapper;
using MediatR;
using ReservaHotel.Application.Amenities.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Amenities.Handlers
{
    /// <summary>
    /// Handles amenity creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateAmenityCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateAmenityHandler : IRequestHandler<CreateAmenityCommand, CustomWebResponse>
    {
        private readonly IRepository<Amenity> _repo;
        private readonly IMapper _mapper;

        public CreateAmenityHandler(IRepository<Amenity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateAmenityCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Amenity>(request.Amenity);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.AmenityDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the amenity."
                };
            }
        }
    }
}