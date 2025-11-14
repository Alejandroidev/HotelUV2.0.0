using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Users.Commands
{
    /// <summary>
    /// Command to create a new user.
    /// </summary>
    /// <param name="User">User DTO payload.</param>
    public record CreateUserCommand(UserDto User) : IRequest<CustomWebResponse>;
}