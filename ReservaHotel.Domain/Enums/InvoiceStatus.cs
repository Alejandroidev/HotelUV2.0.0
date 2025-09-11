namespace ReservaHotel.Domain.Enums
{
    /// <summary>
    /// Defines the possible statuses for an invoice.
    /// </summary>
    public enum InvoiceStatus
    {
        Draft,
        Issued,
        Paid,
        Overdue,
        Cancelled
    }
}