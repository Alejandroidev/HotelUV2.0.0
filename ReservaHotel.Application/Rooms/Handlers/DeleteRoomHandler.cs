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
    /// Handles room deletion.
    /// Example usage:
    /// try { var res = await _mediator.Send(new DeleteRoomCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, CustomWebResponse>
    {
        private readonly IRepository<Room> _repo;

        public DeleteRoomHandler(IRepository<Room> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteRoomCommand request, CancellationToken ct)
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
                    Message = "An unexpected error occurred while deleting the room."
                };
            }
        }
    }
}