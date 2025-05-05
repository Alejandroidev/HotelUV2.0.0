using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;
public class StatusBookingDto : IDto
{
    public int IdEstadoReserva { get; set; }
    public string NombreEstado { get; set; } = null!;

    public ICollection<BookingDto> Reservas { get; set; } = new List<BookingDto>();
}