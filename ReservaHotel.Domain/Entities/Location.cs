using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Collections.Generic;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a hotel location (e.g., a city or country).
    /// </summary>
    public class Location : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name of the location (e.g., "New York", "Madrid").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the hotel at this location.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the collection of rooms at this location.
        /// </summary>
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        /// <summary>
        /// Gets or sets the collection of employees working at this location.
        /// </summary>
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}