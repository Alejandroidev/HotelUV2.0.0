using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.CustomerInteractions.Commands
{
    /// <summary>
    /// Command to delete a customer interaction by identifier.
    /// </summary>
    /// <param name="Id">Customer interaction identifier.</param>
    public record DeleteCustomerInteractionCommand(Guid Id) : IRequest<CustomWebResponse>;
}