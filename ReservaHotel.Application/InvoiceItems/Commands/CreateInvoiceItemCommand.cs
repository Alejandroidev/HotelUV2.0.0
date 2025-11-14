using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.InvoiceItems.Commands
{
    /// <summary>
    /// Command to create a new invoice item.
    /// </summary>
    /// <param name="InvoiceItem">Invoice item DTO payload.</param>
    public record CreateInvoiceItemCommand(InvoiceItemDto InvoiceItem) : IRequest<CustomWebResponse>;
}