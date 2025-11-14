using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Bookings.Commands
{
    /// <summary>
    /// Command to update an existing booking.
    /// </summary>
    /// <param name="Id">Booking identifier.</param>
    /// <param name="Booking">Updated booking DTO.</param>
    public record UpdateBookingCommand(Guid Id, BookingDto Booking) : IRequest<CustomWebResponse>;
}