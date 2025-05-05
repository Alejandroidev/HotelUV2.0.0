using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto
{
    public class TypeRoomDto : IDto
    {
        public int IdTipoHabitacion { get; set; }
        public string NombreTipo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public ICollection<RoomDto> Habitaciones { get; set; } = new List<RoomDto>();
    }
}
