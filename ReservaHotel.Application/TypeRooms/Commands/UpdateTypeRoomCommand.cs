using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.TypeRooms.Commands
{
    /// <summary>
    /// Command to update an existing room type.
    /// </summary>
    /// <param name="Id">Room type identifier.</param>
    /// <param name="TypeRoom">Updated room type DTO.</param>
    public record UpdateTypeRoomCommand(Guid Id, TypeRoomDto TypeRoom) : IRequest<CustomWebResponse>;
}