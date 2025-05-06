using ReservaHotel.Domain.Entities.Hotel;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;

public class RoomDto : IDto
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public int Floor { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int RoomTypeId { get; set; }

    public TypeRoom RoomType { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

