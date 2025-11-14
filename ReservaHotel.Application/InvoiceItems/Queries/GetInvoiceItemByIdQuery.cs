using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.InvoiceItems.Queries
{
    /// <summary>
    /// Query to retrieve an invoice item by identifier.
    /// </summary>
    /// <param name="Id">Invoice item identifier.</param>
    public record GetInvoiceItemByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}