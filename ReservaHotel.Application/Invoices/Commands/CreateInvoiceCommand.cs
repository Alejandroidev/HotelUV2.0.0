using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Invoices.Commands
{
    /// <summary>
    /// Command to create a new invoice.
    /// </summary>
    /// <param name="Invoice">Invoice DTO payload.</param>
    public record CreateInvoiceCommand(InvoiceDto Invoice) : IRequest<CustomWebResponse>;
}