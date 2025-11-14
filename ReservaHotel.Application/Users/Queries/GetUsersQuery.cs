using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Users.Queries
{
    /// <summary>
    /// Query to list all users.
    /// </summary>
    public record GetUsersQuery() : IRequest<CustomWebResponse>;
}