using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.RoomAmenities.Commands
{
    /// <summary>
    /// Command to add an amenity to a room.
    /// </summary>
    /// <param name="RoomId">Room identifier.</param>
    /// <param name="AmenityId">Amenity identifier.</param>
    public record AddRoomAmenityCommand(Guid RoomId, Guid AmenityId) : IRequest<CustomWebResponse>;
}