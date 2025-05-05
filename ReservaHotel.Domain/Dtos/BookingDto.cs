using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;

public class BookingDto : IDto
{
    public int IdReserva { get; set; }
    public int IdCliente { get; set; }
    public int IdHabitacion { get; set; }
    public int IdEstadoReserva { get; set; }
    public int IdUsuarioSistema { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public ClientDto Cliente { get; set; } = null!;
    public RoomDto Habitacion { get; set; } = null!;
    public StatusBookingDto EstadoReserva { get; set; } = null!;
    public SystemUserDto UsuarioSistema { get; set; } = null!;
    public ItineraryDto Itinerario { get; set; } = null!;
}
