using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.RoomAmenities.Queries
{
    /// <summary>
    /// Query to list rooms that include a given amenity.
    /// </summary>
    /// <param name="AmenityId">Amenity identifier.</param>
    public record GetRoomsByAmenityQuery(Guid AmenityId) : IRequest<CustomWebResponse>;
}