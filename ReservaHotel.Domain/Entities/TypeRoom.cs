using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace ReservaHotel.Domain.Entities
{
    public class TypeRoom : BaseEntity<int>, IAggregateRoot
    {
        public string TypeName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
