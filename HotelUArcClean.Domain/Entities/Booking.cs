namespace HotelUColombia.Models
{
    /// <summary>
    /// Creado por Alejandro Salcedo
    /// </summary>
    public class Booking : BaseClass
    {
        /// <summary>
        /// Get or Set IdRoom
        /// </summary>
        public int IdRoom { get; set; }

        /// <summary>
        /// Get or Set IdCliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Get or Set IdStatus
        /// </summary>
        public int IdStatus { get; set; }

        /// <summary>
        /// Get or Set IdUsuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// Get or Set IdUsuario
        /// </summary>
        public int IdItinerary { get; set; }

        /// <summary>
        /// Get or Set ValorDaily
        /// </summary>
        public double ValorTotal { get; set; }

        /// <summary>
        /// Rooms Relationship
        /// </summary>
        public Rooms Rooms { get; set; }

        /// <summary>
        /// Rooms Relationship
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Status Relationship
        /// </summary>
        public StatusBooking Status { get; set; }

        /// <summary>
        /// bookings relationship
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Itinerary Relationship
        /// </summary>
        public Itinerary Itinerary { get; set; }

    }
}
