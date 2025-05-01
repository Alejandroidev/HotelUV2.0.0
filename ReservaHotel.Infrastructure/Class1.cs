using Microsoft.EntityFrameworkCore;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Persistence
{
    public class ReservaHotelDbContext : DbContext
    {
        public ReservaHotelDbContext(DbContextOptions<ReservaHotelDbContext> options)
            : base(options)
        {
            
        }

        // DbSets
        public DbSet<UsuarioSistema> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Puedes añadir aquí configuraciones con Fluent API si lo necesitas
        }
    }
}