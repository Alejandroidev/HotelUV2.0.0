using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.StatusBookings.Commands
{
    /// <summary>
    /// Command to delete a booking status by identifier.
    /// </summary>
    /// <param name="Id">Status identifier.</param>
    public record DeleteStatusBookingCommand(Guid Id) : IRequest<CustomWebResponse>;
}