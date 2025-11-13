using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Rooms.Commands
{
    public record DeleteRoomCommand(Guid Id) : IRequest<CustomWebResponse>;
}