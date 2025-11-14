using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Rooms.Commands
{
    /// <summary>
    /// Command to delete a room by its identifier.
    /// </summary>
    /// <param name="Id">Room identifier.</param>
    public record DeleteRoomCommand(Guid Id) : IRequest<CustomWebResponse>;
}