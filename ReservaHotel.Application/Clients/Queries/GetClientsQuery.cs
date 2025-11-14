using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Clients.Queries
{
    /// <summary>
    /// Query to list all clients.
    /// </summary>
    public record GetClientsQuery() : IRequest<CustomWebResponse>;
}