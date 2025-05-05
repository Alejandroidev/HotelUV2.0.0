using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto;

public class RoomDto : IDto
{
    public int IdHabitacion { get; set; }
    public string Numero { get; set; } = null!;
    public int Piso { get; set; }
    public decimal Precio { get; set; }
    public int Capacidad { get; set; }
    public int IdTipoHabitacion { get; set; }

    public TypeRoomDto TipoHabitacion { get; set; } = null!;
    public ICollection<BookingDto> Reservas { get; set; } = new List<BookingDto>();
}

