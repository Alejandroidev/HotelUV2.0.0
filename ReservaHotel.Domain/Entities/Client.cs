using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities
{
    public class Client : BaseEntity<int>, IAggregateRoot
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
