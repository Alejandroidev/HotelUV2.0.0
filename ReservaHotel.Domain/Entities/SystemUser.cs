using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace ReservaHotel.Domain.Entities;
public class SystemUser : BaseEntity<int>, IAggregateRoot
{
    public string Username { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    [JsonIgnore]
    public ICollection<Booking> RegisteredBookings { get; set; } = new List<Booking>();
}