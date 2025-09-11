using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Common.Dtos;

namespace ReservaHotel.Application.Interfaces
{
    public interface IItineraryService : IServiceCrud<ItineraryDto, int>
    {
    }
}
