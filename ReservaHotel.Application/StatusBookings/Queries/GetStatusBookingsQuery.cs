using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.StatusBookings.Queries
{
    /// <summary>
    /// Query to list all booking statuses.
    /// </summary>
    public record GetStatusBookingsQuery() : IRequest<CustomWebResponse>;
}