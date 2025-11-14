using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.TypeRooms.Commands
{
    /// <summary>
    /// Command to create a new room type.
    /// </summary>
    /// <param name="TypeRoom">Room type DTO payload.</param>
    public record CreateTypeRoomCommand(TypeRoomDto TypeRoom) : IRequest<CustomWebResponse>;
}