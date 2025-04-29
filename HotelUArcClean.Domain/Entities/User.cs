namespace HotelUColombia.Models
{
    /// <summary>
    /// Creado por Sergio Duarte
    /// </summary>
    public class User : BaseClass
    {
        /// <summary>
        /// Get or Set Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Get or Set LastName
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Get or Set LastName
        /// </summary>
        public string? Rol { get; set; }

        /// <summary>
        /// Get or Ser Rol
        /// </summary>
        public string? Correo { get; set; }

        /// <summary>
        /// Get or Ser Comments
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// Get or Ser User_Name
        /// </summary>
        public string? User_Name { get; set; }

        /// <summary>
        /// Get or Ser Password
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// bookings relationship
        /// </summary>
        public IEnumerable<Booking>? Bookings { get; set; }
    }
}
