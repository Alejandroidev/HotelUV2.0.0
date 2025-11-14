using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.InvoiceItems.Commands
{
    /// <summary>
    /// Command to delete an invoice item by identifier.
    /// </summary>
    /// <param name="Id">Invoice item identifier.</param>
    public record DeleteInvoiceItemCommand(Guid Id) : IRequest<CustomWebResponse>;
}