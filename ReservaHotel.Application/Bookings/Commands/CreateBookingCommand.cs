using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Bookings.Commands
{
    /// <summary>
    /// Command to create a new booking.
    /// </summary>
    /// <param name="Booking">DTO payload containing booking data.</param>
    public record CreateBookingCommand(BookingDto Booking) : IRequest<CustomWebResponse>;
}