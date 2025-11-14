using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.InvoiceItems.Queries
{
    /// <summary>
    /// Query to list all invoice items.
    /// </summary>
    public record GetInvoiceItemsQuery() : IRequest<CustomWebResponse>;
}