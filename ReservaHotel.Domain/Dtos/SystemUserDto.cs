using ReservaHotel.Domain.Entities.Hotel;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;
public class SystemUserDto : IDto
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public ICollection<Booking> RegisteredBookings { get; set; } = new List<Booking>();
}