using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Application.Common.Dtos;
public class StatusBookingDto : IDto
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}