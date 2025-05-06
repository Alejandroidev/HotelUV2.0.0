using ReservaHotel.Domain.Entities.Hotel;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;
public class StatusBookingDto : IDto
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}