using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Rooms.Commands
{
    /// <summary>
    /// Command to update an existing room.
    /// </summary>
    /// <param name="Id">Room identifier.</param>
    /// <param name="Room">Updated room DTO.</param>
    public record UpdateRoomCommand(Guid Id, RoomDto Room) : IRequest<CustomWebResponse>;
}