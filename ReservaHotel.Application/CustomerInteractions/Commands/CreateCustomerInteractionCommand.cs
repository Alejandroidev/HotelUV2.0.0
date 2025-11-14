using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.CustomerInteractions.Commands
{
    /// <summary>
    /// Command to create a new customer interaction.
    /// </summary>
    /// <param name="CustomerInteraction">Customer interaction DTO payload.</param>
    public record CreateCustomerInteractionCommand(CustomerInteractionDto CustomerInteraction) : IRequest<CustomWebResponse>;
}