using Microsoft.EntityFrameworkCore;
using ReservaHotel.Domain.Entities.Hotel;
using System.Reflection;

namespace ReservaHotel.Infrastructure.Persistence
{
    public class ReservaHotelDbContext : DbContext
    {
        public ReservaHotelDbContext(DbContextOptions<ReservaHotelDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Client> Clientes { get; set; }
        public DbSet<StatusBooking> EstadoReserva { get; set; }
        public DbSet<Room> Habitacion { get; set; }
        public DbSet<Itinerary> Itinerarios { get; set; }
        public DbSet<Booking> Reservas { get; set; }
        public DbSet<TypeRoom> TipoHabitacion { get; set; }
        public DbSet<SystemUser> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}