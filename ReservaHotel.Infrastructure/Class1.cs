using Microsoft.EntityFrameworkCore;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Persistence
{
    public class ReservaHotelDbContext : DbContext
    {
        public ReservaHotelDbContext(DbContextOptions<ReservaHotelDbContext> options)
            : base(options)
        {
            
        }

        // DbSets
        public DbSet<SystemUser> Usuarios { get; set; }
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Room> Habitaciones { get; set; }
        public DbSet<Booking> Reservas { get; set; }
        public DbSet<Itinerary> Itinerarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Puedes añadir aquí configuraciones con Fluent API si lo necesitas
        }
    }
}