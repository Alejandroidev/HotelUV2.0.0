using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Invoices.Queries
{
    /// <summary>
    /// Query to retrieve an invoice by identifier.
    /// </summary>
    /// <param name="Id">Invoice identifier.</param>
    public record GetInvoiceByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}