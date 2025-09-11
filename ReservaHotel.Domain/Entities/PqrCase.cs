using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Enums;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a PQR (Petition, Complaint, or Claim) case filed by a client.
    /// </summary>
    public class PqrCase : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the client who filed the PQR.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the client.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the optional unique identifier for a booking related to the PQR.
        /// </summary>
        public Guid? BookingId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the booking.
        /// </summary>
        public Booking Booking { get; set; }

        /// <summary>
        /// Gets or sets the type of the PQR (Petition, Complaint, or Claim).
        /// </summary>
        public PqrType PqrType { get; set; }

        /// <summary>
        /// Gets or sets the current status of the PQR case.
        /// </summary>
        public PqrStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the subject or title of the PQR.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the detailed description of the PQR.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date the PQR was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date the PQR was resolved or closed.
        /// </summary>
        public DateTime? ResolvedAt { get; set; }
    }
}