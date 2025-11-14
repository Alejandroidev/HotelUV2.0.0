using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.RoomAmenities.Queries
{
    /// <summary>
    /// Query to list amenities of a room.
    /// </summary>
    /// <param name="RoomId">Room identifier.</param>
    public record GetAmenitiesByRoomQuery(Guid RoomId) : IRequest<CustomWebResponse>;
}