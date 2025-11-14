using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Invoices.Queries
{
    /// <summary>
    /// Query to list all invoices.
    /// </summary>
    public record GetInvoicesQuery() : IRequest<CustomWebResponse>;
}