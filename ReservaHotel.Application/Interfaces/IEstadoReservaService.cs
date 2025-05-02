using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Application.Interfaces
{
    public interface IEstadoReservaService
    {
        Task<IEnumerable<EstadoReserva>> GetAllEstadosAsync();
        Task<EstadoReserva> GetEstadoByIdAsync(int id);
        Task AddEstadoAsync(EstadoReserva estadoReserva);
        Task UpdateEstadoAsync(EstadoReserva estadoReserva);
        Task DeleteEstadoAsync(int id);
    }
}
