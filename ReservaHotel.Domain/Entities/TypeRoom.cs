using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Collections.Generic;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a type of hotel room (e.g., Single, Double, Suite).
    /// </summary>
    public class TypeRoom : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name of the room type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the room type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of rooms of this type.
        /// </summary>
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
