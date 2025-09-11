using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Enums;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a hotel room.
    /// </summary>
    public class Room : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the type of room.
        /// </summary>
        public Guid TypeRoomId { get; set; }

        /// <summary>
        /// Gets or sets the name or number of the room.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the room.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price per night for the room.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of guests the room can accommodate.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the current operational status of the room.
        /// </summary>
        public RoomStatus Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room is featured or recommended.
        /// </summary>
        public bool IsFeatured { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the room's type.
        /// </summary>
        public TypeRoom TypeRoom { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the location of the room.
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the collection of bookings associated with this room.
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        /// <summary>
        /// Gets or sets the collection of amenities for this room.
        /// </summary>
        public ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
    }
}