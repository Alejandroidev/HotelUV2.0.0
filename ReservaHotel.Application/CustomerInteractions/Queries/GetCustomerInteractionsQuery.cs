using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.CustomerInteractions.Queries
{
    /// <summary>
    /// Query to list all customer interactions.
    /// </summary>
    public record GetCustomerInteractionsQuery() : IRequest<CustomWebResponse>;
}