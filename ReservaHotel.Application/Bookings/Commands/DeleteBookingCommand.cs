using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Bookings.Commands
{
    /// <summary>
    /// Command to delete an existing booking by its identifier.
    /// </summary>
    /// <param name="Id">Unique booking identifier.</param>
    public record DeleteBookingCommand(Guid Id) : IRequest<CustomWebResponse>;
}