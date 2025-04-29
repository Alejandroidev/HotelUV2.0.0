namespace HotelUColombia.Models
{
    /// <summary>
    /// Creado por Harold Calderon
    /// </summary>
    public class StatusBooking : BaseClass
    {
        /// <summary>
        /// Get or Set Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// bookings relationship
        /// </summary>
        public IEnumerable<Booking> Booking { get; set; }
    }
}
