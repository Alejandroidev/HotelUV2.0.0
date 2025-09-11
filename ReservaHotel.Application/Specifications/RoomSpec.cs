using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Application.Specifications
{
    public class RoomSpec : GeneralSpecification<int, Room>
    {
        public RoomSpec() { }
        public RoomSpec(int id) : base(id) { }



    }
}
