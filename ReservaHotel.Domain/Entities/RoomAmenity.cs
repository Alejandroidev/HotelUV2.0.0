using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents the join entity for the many-to-many relationship between Room and Amenity.
    /// </summary>
    public class RoomAmenity : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the room.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the room.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the amenity.
        /// </summary>
        public Guid AmenityId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the amenity.
        /// </summary>
        public Amenity Amenity { get; set; }
    }
}
