using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    public class Itinerary : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
