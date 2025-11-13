using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos
{
    public class ItineraryDto : IDto
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
