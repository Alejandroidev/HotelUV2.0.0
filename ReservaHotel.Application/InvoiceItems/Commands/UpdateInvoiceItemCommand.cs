using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.InvoiceItems.Commands
{
    /// <summary>
    /// Command to update an existing invoice item.
    /// </summary>
    /// <param name="Id">Invoice item identifier.</param>
    /// <param name="InvoiceItem">Updated invoice item DTO.</param>
    public record UpdateInvoiceItemCommand(Guid Id, InvoiceItemDto InvoiceItem) : IRequest<CustomWebResponse>;
}