

namespace HotelUColombia.Models
{
    /// <summary>
    /// Creado por Nathalia Gaona
    /// </summary>
    public class Itinerary : BaseClass
    {
        /// <summary>
        /// Get or Set PickUp
        /// </summary>
        public DateTime PickUp { get; set; }

        /// <summary>
        /// Get or Set PickDown
        /// </summary>
        public DateTime PickDown { get; set; }

        /// <summary>
        /// Get or Set Create
        /// </summary>
        public DateTime Create { get; set; } = DateTime.Now;

        /// <summary>
        /// Get or Set IdTypeRoom
        /// </summary>
        public int IdRoom { get; set; }

        /// <summary>
        /// Rooms Relationship
        /// </summary>
        public Rooms Rooms { get; set; }

        /// <summary>
        /// bookings relationship
        /// </summary>
        public IEnumerable<Booking>? Bookings { get; set; }






    }
}
