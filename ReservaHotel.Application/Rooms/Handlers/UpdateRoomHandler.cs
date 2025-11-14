using AutoMapper;
using MediatR;
using ReservaHotel.Application.Rooms.Commands;
using ReservaHotel.Application.Rooms.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Rooms.Handlers
{
    /// <summary>
    /// Handles room updates.
    /// Example usage:
    /// try { var res = await _mediator.Send(new UpdateRoomCommand(id, dto), ct); } catch (Exception ex) { /* log */ }
    /// </summary>
    public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, CustomWebResponse>
    {
        private readonly IRepository<Room> _repo;
        private readonly IMapper _mapper;

        public UpdateRoomHandler(IRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(UpdateRoomCommand request, CancellationToken ct)
        {
            try
            {
                var spec = new RoomByIdSpec(request.Id);
                var entity = await _repo.FirstOrDefaultAsync(spec, ct);
                if (entity == null)
                {
                    return new CustomWebResponse(true)
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Room not found"
                    };
                }

                _mapper.Map(request.Room, entity);
                await _repo.UpdateAsync(entity, ct);

                return new CustomWebResponse
                {
                    ResponseBody = _mapper.Map<Application.Common.Dtos.RoomDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while updating the room."
                };
            }
        }
    }
}