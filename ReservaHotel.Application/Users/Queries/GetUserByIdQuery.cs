using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Users.Queries
{
    /// <summary>
    /// Query to retrieve a user by identifier.
    /// </summary>
    /// <param name="Id">User identifier.</param>
    public record GetUserByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}