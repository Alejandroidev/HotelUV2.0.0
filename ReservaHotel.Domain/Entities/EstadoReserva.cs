using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Domain.Entities;
public class EstadoReserva
{
    public int IdEstadoReserva { get; set; }
    public string NombreEstado { get; set; } = null!;

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}