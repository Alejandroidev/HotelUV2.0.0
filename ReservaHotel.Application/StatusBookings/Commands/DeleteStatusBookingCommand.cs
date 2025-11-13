using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.StatusBookings.Commands
{
    public record DeleteStatusBookingCommand(Guid Id) : IRequest<CustomWebResponse>;
}