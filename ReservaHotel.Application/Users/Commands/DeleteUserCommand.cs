using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Users.Commands
{
    /// <summary>
    /// Command to delete a user by identifier.
    /// </summary>
    /// <param name="Id">User identifier.</param>
    public record DeleteUserCommand(Guid Id) : IRequest<CustomWebResponse>;
}