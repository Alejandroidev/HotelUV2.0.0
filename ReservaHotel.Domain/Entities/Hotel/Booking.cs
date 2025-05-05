using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities.Hotel;

public class Booking : BaseEntity<int>, IAggregateRoot
{
    public int IdReserva { get; set; }
    public int IdCliente { get; set; }
    public int IdHabitacion { get; set; }
    public int IdEstadoReserva { get; set; }
    public int IdUsuarioSistema { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public Client Cliente { get; set; } = null!;
    public Room Habitacion { get; set; } = null!;
    public StatusBooking EstadoReserva { get; set; } = null!;
    public SystemUser UsuarioSistema { get; set; } = null!;
    public Itinerary Itinerario { get; set; } = null!;
}
