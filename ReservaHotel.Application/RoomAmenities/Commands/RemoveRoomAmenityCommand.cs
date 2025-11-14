using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.RoomAmenities.Commands
{
    /// <summary>
    /// Command to remove an amenity from a room.
    /// </summary>
    /// <param name="RoomId">Room identifier.</param>
    /// <param name="AmenityId">Amenity identifier.</param>
    public record RemoveRoomAmenityCommand(Guid RoomId, Guid AmenityId) : IRequest<CustomWebResponse>;
}