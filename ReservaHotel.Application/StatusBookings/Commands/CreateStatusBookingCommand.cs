using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.StatusBookings.Commands
{
    public record CreateStatusBookingCommand(StatusBookingDto StatusBooking) : IRequest<CustomWebResponse>;
}