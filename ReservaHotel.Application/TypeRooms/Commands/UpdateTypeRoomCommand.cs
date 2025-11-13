using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.TypeRooms.Commands
{
    public record UpdateTypeRoomCommand(Guid Id, TypeRoomDto TypeRoom) : IRequest<CustomWebResponse>;
}