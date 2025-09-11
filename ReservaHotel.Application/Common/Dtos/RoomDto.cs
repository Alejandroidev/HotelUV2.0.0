using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Application.Common.Dtos;

public class RoomDto : IDto
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public int Floor { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int RoomTypeId { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

