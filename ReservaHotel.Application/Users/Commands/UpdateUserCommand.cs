using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Users.Commands
{
    /// <summary>
    /// Command to update an existing user.
    /// </summary>
    /// <param name="Id">User identifier.</param>
    /// <param name="User">Updated user DTO.</param>
    public record UpdateUserCommand(Guid Id, UserDto User) : IRequest<CustomWebResponse>;
}