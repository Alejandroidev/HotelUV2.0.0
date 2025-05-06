using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities.Hotel
{
    public class Itinerary : BaseEntity<int>, IAggregateRoot
    {
        public int BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
