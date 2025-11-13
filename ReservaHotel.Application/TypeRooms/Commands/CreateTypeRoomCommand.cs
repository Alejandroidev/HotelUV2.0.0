using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.TypeRooms.Commands
{
    public record CreateTypeRoomCommand(TypeRoomDto TypeRoom) : IRequest<CustomWebResponse>;
}