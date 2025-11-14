using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Commands
{
    /// <summary>
    /// Command to create a new room.
    /// </summary>
    /// <param name="Room">Room DTO payload.</param>
    public record CreateRoomCommand(RoomDto Room) : IRequest<CustomWebResponse>;
}