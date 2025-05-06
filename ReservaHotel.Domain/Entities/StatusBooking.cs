using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace ReservaHotel.Domain.Entities;
public class StatusBooking : BaseEntity<int>, IAggregateRoot
{
    public string StatusName { get; set; } = null!;
    [JsonIgnore]
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}