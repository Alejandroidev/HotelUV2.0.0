using Microsoft.EntityFrameworkCore;
using ReservaHotel.Domain.Entities;
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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoReserva> EstadoReserva { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoHabitacion> TipoHabitacion { get; set; }
        public DbSet<UsuarioSistema> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}