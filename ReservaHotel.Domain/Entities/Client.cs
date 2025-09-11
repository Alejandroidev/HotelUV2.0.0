using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Collections.Generic;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a client of the hotel.
    /// </summary>
    public class Client : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the client's first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the client's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the client's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the client's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the collection of bookings associated with this client.
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        /// <summary>
        /// Gets or sets the collection of interactions with this client for CRM purposes.
        /// </summary>
        public ICollection<CustomerInteraction> Interactions { get; set; } = new List<CustomerInteraction>();
    }
}