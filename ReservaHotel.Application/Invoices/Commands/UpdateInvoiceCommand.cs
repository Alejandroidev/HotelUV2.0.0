using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Invoices.Commands
{
    /// <summary>
    /// Command to update an existing invoice.
    /// </summary>
    /// <param name="Id">Invoice identifier.</param>
    /// <param name="Invoice">Updated invoice DTO.</param>
    public record UpdateInvoiceCommand(Guid Id, InvoiceDto Invoice) : IRequest<CustomWebResponse>;
}