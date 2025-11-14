using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.StatusBookings.Queries
{
    /// <summary>
    /// Query to retrieve a booking status by identifier.
    /// </summary>
    /// <param name="Id">Status identifier.</param>
    public record GetStatusBookingByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}