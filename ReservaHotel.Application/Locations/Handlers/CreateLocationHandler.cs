using AutoMapper;
using MediatR;
using ReservaHotel.Application.Locations.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Locations.Handlers
{
    /// <summary>
    /// Handles location creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateLocationCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, CustomWebResponse>
    {
        private readonly IRepository<Location> _repo;
        private readonly IMapper _mapper;

        public CreateLocationHandler(IRepository<Location> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateLocationCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Location>(request.Location);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.LocationDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the location."
                };
            }
        }
    }
}