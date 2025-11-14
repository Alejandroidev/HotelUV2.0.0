using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Clients.Commands
{
    /// <summary>
    /// Command to create a new client.
    /// </summary>
    /// <param name="Client">Client DTO payload.</param>
    public record CreateClientCommand(ClientDto Client) : IRequest<CustomWebResponse>;
}