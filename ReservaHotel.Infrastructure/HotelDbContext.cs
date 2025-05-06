using Microsoft.EntityFrameworkCore;
using ReservaHotel.Domain.Entities;
using System.Reflection;

namespace ReservaHotel.Infrastructure.Persistence
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            // Patch for Postgres DateTime variables
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<StatusBooking> StatusBooking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Itinerary> Itinerary { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<TypeRoom> TypeRoom { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}