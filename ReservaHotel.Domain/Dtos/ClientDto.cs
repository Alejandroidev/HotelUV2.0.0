using ReservaHotel.Domain.Entities.Hotel;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto
{
    public class ClientDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
