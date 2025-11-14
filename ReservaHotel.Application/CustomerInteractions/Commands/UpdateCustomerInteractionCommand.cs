using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.CustomerInteractions.Commands
{
    /// <summary>
    /// Command to update an existing customer interaction.
    /// </summary>
    /// <param name="Id">Customer interaction identifier.</param>
    /// <param name="CustomerInteraction">Updated customer interaction DTO.</param>
    public record UpdateCustomerInteractionCommand(Guid Id, CustomerInteractionDto CustomerInteraction) : IRequest<CustomWebResponse>;
}