using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto
{
    public class TypeRoomDto : IDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
