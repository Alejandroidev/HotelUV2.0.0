using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Dto;

namespace ReservaHotel.Application.Interfaces
{
    public interface IClientService : IServiceCrud<ClientDto, int>
    {
    }
}
