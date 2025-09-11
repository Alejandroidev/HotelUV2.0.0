using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Collections.Generic;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents the status of a booking (e.g., Confirmed, Canceled, Pending).
    /// </summary>
    public class StatusBooking : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name of the status.
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Gets or sets the collection of bookings with this status.
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}