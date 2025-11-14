using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Rooms.Handlers
{
    /// <summary>
    /// Handles CreateRoomCommand requests to create a new Room entity.
    /// Example usage:
    /// try {
    ///   var response = await _mediator.Send(new CreateRoomCommand(dto), ct);
    ///   // check response.Success and return Created
    /// } catch (Exception ex) {
    ///   _logger.LogError(ex, "Error creating room");
    /// }
    /// </summary>
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, CustomWebResponse>
    {
        private readonly IRepository<Room> _repo;
        private readonly IMapper _mapper;

        public CreateRoomHandler(IRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateRoomCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Room>(request.Room);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.RoomDto>(entity)
                };
            }
            catch (Exception ex)
            {
                // Best practice: never leak internal exception details to clients.
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the room."
                };
            }
        }
    }
}