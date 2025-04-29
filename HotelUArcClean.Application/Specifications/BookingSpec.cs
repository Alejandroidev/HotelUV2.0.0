namespace HotelUColombia.Models
{
    /// <summary>
    /// Creado por Alejandro Salcedo
    /// </summary>
    public class BookingSpec : BaseSpecification<Booking>
    {
        /// <summary>
        /// Get or Set Id
        /// </summary>
        public BookingSpec(int id) : base(x => x.Id == id)
        {
        }
    }
}
