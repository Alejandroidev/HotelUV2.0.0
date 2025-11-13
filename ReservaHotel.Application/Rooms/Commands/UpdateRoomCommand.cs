using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Rooms.Commands
{
    public record UpdateRoomCommand(Guid Id, RoomDto Room) : IRequest<CustomWebResponse>;
}