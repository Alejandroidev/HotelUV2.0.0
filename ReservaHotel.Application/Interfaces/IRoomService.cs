using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Dto;

namespace ReservaHotel.Application.Interfaces
{
    public interface IRoomService : IServiceCrud<RoomDto, int>
    {
    }
}
