using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.CustomerInteractions.Queries
{
    /// <summary>
    /// Query to retrieve a customer interaction by identifier.
    /// </summary>
    /// <param name="Id">Customer interaction identifier.</param>
    public record GetCustomerInteractionByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}