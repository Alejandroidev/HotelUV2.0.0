using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities;

public class Booking : BaseEntity<int>, IAggregateRoot
{
    public int ClientId { get; set; }
    public int RoomId { get; set; }
    public int StatusBookingId { get; set; }
    public int SystemUserId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Client Client { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public StatusBooking BookingStatus { get; set; } = null!;
    public SystemUser SystemUser { get; set; } = null!;
    public Itinerary Itinerary { get; set; } = null!;
}
