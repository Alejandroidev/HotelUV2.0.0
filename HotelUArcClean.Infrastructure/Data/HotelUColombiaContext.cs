using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace HotelUColombia.Data
{
    public class HotelUColombiaContext : DbContext
    {

        public HotelUColombiaContext(DbContextOptions<HotelUColombiaContext> options)
             : base(options)
        {
        }


        public DbSet<Booking> Booking { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Itinerary> Itinerary { get; set; } = default!;
        public DbSet<Rooms> Rooms { get; set; } = default!;
        public DbSet<StatusBooking> StatusBooking { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(HotelUColombiaContext).Assembly);

        }
    }
}
