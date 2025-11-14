using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Bookings.Queries
{
    /// <summary>
    /// Query to retrieve a booking by its identifier.
    /// </summary>
    /// <param name="Id">Unique booking identifier.</param>
    public record GetBookingByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}