using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.TypeRooms.Commands
{
    public record DeleteTypeRoomCommand(Guid Id) : IRequest<CustomWebResponse>;
}