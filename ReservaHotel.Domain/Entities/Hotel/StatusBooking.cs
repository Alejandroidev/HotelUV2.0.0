using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities.Hotel;
public class StatusBooking : BaseEntity<int>, IAggregateRoot
{
    public string StatusName { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}