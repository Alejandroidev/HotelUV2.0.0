using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a booking made by a client for a specific room.
    /// </summary>
    public class Booking : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the check-in date and time for the booking.
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Gets or sets the check-out date and time for the booking.
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// Gets or sets the number of guests for the booking.
        /// </summary>
        public int NumberOfGuests { get; set; }

        /// <summary>
        /// Gets or sets the total price for the booking.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the client associated with the booking.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the client.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the room associated with the booking.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the room.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the status of the booking.
        /// </summary>
        public Guid StatusBookingId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the booking status.
        /// </summary>
        public StatusBooking StatusBooking { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the itinerary associated with this booking.
        /// </summary>
        public Itinerary Itinerary { get; set; }

        /// <summary>
        /// Gets or sets the invoice associated with this booking.
        /// </summary>
        public Invoice Invoice { get; set; }
    }
}