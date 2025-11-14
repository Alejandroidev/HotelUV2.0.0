using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Clients.Commands
{
    /// <summary>
    /// Command to delete a client.
    /// </summary>
    /// <param name="Id">Client identifier.</param>
    public record DeleteClientCommand(Guid Id) : IRequest<CustomWebResponse>;
}