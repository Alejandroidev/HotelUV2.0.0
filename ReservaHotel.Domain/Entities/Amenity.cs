using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Collections.Generic;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents an amenity that a room can offer (e.g., Wi-Fi, Air Conditioning).
    /// </summary>
    public class Amenity : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name of the amenity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the amenity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of room-amenity associations.
        /// </summary>
        public ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
    }
}