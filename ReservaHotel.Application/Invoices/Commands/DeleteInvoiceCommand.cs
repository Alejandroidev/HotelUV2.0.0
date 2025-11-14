using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Invoices.Commands
{
    /// <summary>
    /// Command to delete an invoice by identifier.
    /// </summary>
    /// <param name="Id">Invoice identifier.</param>
    public record DeleteInvoiceCommand(Guid Id) : IRequest<CustomWebResponse>;
}