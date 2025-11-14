using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Clients.Commands
{
    /// <summary>
    /// Command to update an existing client.
    /// </summary>
    /// <param name="Id">Client identifier.</param>
    /// <param name="Client">Updated client DTO.</param>
    public record UpdateClientCommand(Guid Id, ClientDto Client) : IRequest<CustomWebResponse>;
}