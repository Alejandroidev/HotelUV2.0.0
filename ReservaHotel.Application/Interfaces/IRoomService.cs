using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Interfaces
{
    public interface IRoomService : IServiceCrud<RoomDto, int>
    {
        public Task<CustomWebResponse> GetAvailableRooms(bool IsFeatured, CancellationToken ct = default);
    }
}
