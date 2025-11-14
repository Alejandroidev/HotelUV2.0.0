using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Bookings.Queries
{
    /// <summary>
    /// Query to retrieve all bookings.
    /// </summary>
    public record GetBookingsQuery() : IRequest<CustomWebResponse>;
}