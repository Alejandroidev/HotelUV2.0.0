using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.TypeRooms.Queries
{
    /// <summary>
    /// Query to retrieve a room type by identifier.
    /// </summary>
    /// <param name="Id">Room type identifier.</param>
    public record GetTypeRoomByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}