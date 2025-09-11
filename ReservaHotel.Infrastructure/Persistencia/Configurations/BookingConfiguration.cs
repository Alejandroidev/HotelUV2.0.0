using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.TotalPrice)
                .HasColumnType("decimal(18,2)");

            // Relación con Client
            builder.HasOne(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Room
            builder.HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con StatusBooking
            builder.HasOne(b => b.StatusBooking)
                .WithMany() // StatusBooking no necesita una colección de Bookings
                .HasForeignKey(b => b.StatusBookingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
