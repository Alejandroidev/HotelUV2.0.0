using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Common.Dtos;

namespace ReservaHotel.Application.Interfaces
{
    public interface IClientService : IServiceCrud<ClientDto, int>
    {
    }
}
