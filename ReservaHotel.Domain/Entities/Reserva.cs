using ReservaHotel.Domain.Entities;
namespace ReservaHotel.Domain.Entities;

public class Reserva
{
    public int IdReserva { get; set; }
    public int IdCliente { get; set; }
    public int IdHabitacion { get; set; }
    public int IdEstadoReserva { get; set; }
    public int IdUsuarioSistema { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public Cliente Cliente { get; set; } = null!;
    public Habitacion Habitacion { get; set; } = null!;
    public EstadoReserva EstadoReserva { get; set; } = null!;
    public UsuarioSistema UsuarioSistema { get; set; } = null!;
    public Itinerario Itinerario { get; set; } = null!;
}
