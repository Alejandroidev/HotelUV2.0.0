using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.StatusBookings.Commands
{
    /// <summary>
    /// Command to create a new booking status.
    /// </summary>
    /// <param name="StatusBooking">Status DTO payload.</param>
    public record CreateStatusBookingCommand(StatusBookingDto StatusBooking) : IRequest<CustomWebResponse>;
}