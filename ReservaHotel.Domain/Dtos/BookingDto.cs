using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;

public class BookingDto : IDto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int RoomId { get; set; }
    public int StatusBookingId { get; set; }
    public int SystemUserId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    //public Client Client { get; set; } = null!;
    //public Room Room { get; set; } = null!;
    //public StatusBooking BookingStatus { get; set; } = null!;
    //public SystemUser SystemUser { get; set; } = null!;
    //public Itinerary Itinerary { get; set; } = null!;
}
