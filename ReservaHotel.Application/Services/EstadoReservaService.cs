using ReservaHotel.Application.Interfaces;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ReservaHotel.Application.Specifications;

namespace ReservaHotel.Application.Services
{
    public class EstadoReservaService : IEstadoReservaService
    {
        private readonly ReservaHotelDbContext _context;

        public EstadoReservaService(ReservaHotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadoReserva>> GetAllEstadosAsync()
        {
            return await _context.EstadoReserva.ToListAsync();
        }

        public async Task<EstadoReserva> GetEstadoByIdAsync(int id)
        {
            return await _context.EstadoReserva.FindAsync(id);
        }

        public async Task AddEstadoAsync(EstadoReserva estadoReserva)
        {
            _context.EstadoReserva.Add(estadoReserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstadoAsync(EstadoReserva estadoReserva)
        {
            _context.EstadoReserva.Update(estadoReserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstadoAsync(int id)
        {
            var estadoReserva = await _context.EstadoReserva.FindAsync(id);
            if (estadoReserva != null)
            {
                _context.EstadoReserva.Remove(estadoReserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EstadoReserva> GetEstadoByNombreAsync(string nombre)
        {
            return await _context.EstadoReserva
                .FirstOrDefaultAsync(EstadoReservaByNombreSpecification.IsMatchingNombre(nombre));
        }
    }
}
