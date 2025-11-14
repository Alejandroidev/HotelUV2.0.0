using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.StatusBookings.Commands
{
    /// <summary>
    /// Command to update a booking status by identifier.
    /// </summary>
    /// <param name="Id">Status identifier.</param>
    /// <param name="StatusBooking">Updated status DTO.</param>
    public record UpdateStatusBookingCommand(Guid Id, StatusBookingDto StatusBooking) : IRequest<CustomWebResponse>;
}