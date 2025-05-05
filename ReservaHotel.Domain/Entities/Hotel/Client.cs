using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities.Hotel
{
    public class Client : BaseEntity<int>, IAggregateRoot
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Documento { get; set; } = null!;

        public ICollection<Booking> Reservas { get; set; } = new List<Booking>();
    }
}
