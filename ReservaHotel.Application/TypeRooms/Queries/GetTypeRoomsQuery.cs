using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.TypeRooms.Queries
{
    /// <summary>
    /// Query to list all room types.
    /// </summary>
    public record GetTypeRoomsQuery() : IRequest<CustomWebResponse>;
}