using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Enums;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents an invoice for a booking, compliant with Colombian regulations.
    /// </summary>
    public class Invoice : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the associated booking.
        /// </summary>
        public Guid BookingId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the booking.
        /// </summary>
        public Booking Booking { get; set; }

        /// <summary>
        /// Gets or sets the Unique Electronic Invoice Code (CUFE), required by Colombian law.
        /// </summary>
        public string Cufe { get; set; }

        /// <summary>
        /// Gets or sets the date the invoice was issued.
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the date the invoice is due.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount before taxes.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount (e.g., IVA).
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the invoice.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the current status of the invoice.
        /// </summary>
        public InvoiceStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of line items for this invoice.
        /// </summary>
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}