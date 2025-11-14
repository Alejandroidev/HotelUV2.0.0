using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.TypeRooms.Commands
{
    /// <summary>
    /// Command to delete a room type by identifier.
    /// </summary>
    /// <param name="Id">Room type identifier.</param>
    public record DeleteTypeRoomCommand(Guid Id) : IRequest<CustomWebResponse>;
}