using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.TypeRooms.Queries
{
    public record GetTypeRoomByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}