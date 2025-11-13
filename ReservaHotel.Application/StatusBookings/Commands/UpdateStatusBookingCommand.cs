using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.StatusBookings.Commands
{
    public record UpdateStatusBookingCommand(Guid Id, StatusBookingDto StatusBooking) : IRequest<CustomWebResponse>;
}