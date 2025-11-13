using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a single line item on an invoice.
    /// </summary>
    public class InvoiceItem : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the invoice this item belongs to.
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the invoice.
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the description of the item (e.g., "Room Stay", "Mini-bar consumption").
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price per unit.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total amount for this line item (Quantity * UnitPrice).
        /// </summary>
        public decimal Total { get; set; }
    }
}