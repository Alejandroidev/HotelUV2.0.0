using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace ReservaHotel.Domain.Entities
{
    public class Client : BaseEntity<int>, IAggregateRoot
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }
}
