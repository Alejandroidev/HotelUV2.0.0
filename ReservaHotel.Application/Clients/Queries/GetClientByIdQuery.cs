using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Clients.Queries
{
    /// <summary>
    /// Query to retrieve a client by identifier.
    /// </summary>
    /// <param name="Id">Client identifier.</param>
    public record GetClientByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}