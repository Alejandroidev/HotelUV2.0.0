using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Enums;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a single interaction with a client for CRM purposes.
    /// </summary>
    public class CustomerInteraction : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the client.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the interaction.
        /// </summary>
        public DateTime InteractionDate { get; set; }

        /// <summary>
        /// Gets or sets the type of interaction (e.g., Phone Call, Email).
        /// </summary>
        public InteractionType InteractionType { get; set; }

        /// <summary>
        /// Gets or sets the notes or summary of the interaction.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the system user who handled the interaction.
        /// </summary>
        public Guid? SystemUserId { get; set; } // Nullable if interaction is automated
    }
}