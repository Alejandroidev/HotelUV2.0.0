using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Rooms.Commands
{
    public record CreateRoomCommand(RoomDto Room) : IRequest<CustomWebResponse>;
}