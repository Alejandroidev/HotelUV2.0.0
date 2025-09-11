using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Application.Common.Dtos
{
    public class ItineraryDto : IDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
