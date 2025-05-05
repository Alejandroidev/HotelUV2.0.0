using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities.Hotel;
public class StatusBooking : BaseEntity<int>, IAggregateRoot
{
    public int IdEstadoReserva { get; set; }
    public string NombreEstado { get; set; } = null!;

    public ICollection<Booking> Reservas { get; set; } = new List<Booking>();
}