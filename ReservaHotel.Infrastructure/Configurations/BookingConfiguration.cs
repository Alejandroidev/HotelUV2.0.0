using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CreationDate)
                 .HasColumnType("timestamp with time zone")
                 .IsRequired();
            builder.Property(r => r.StartDate)
                 .HasColumnType("timestamp with time zone")
                 .IsRequired();
            builder.Property(r => r.EndDate)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.HasOne(r => r.Client)
                   .WithMany(c => c.Bookings)
                   .HasForeignKey(r => r.ClientId);

            builder.HasOne(r => r.Room)
                   .WithMany(h => h.Bookings)
                   .HasForeignKey(r => r.RoomId);

            builder.HasOne(r => r.BookingStatus)
                   .WithMany(e => e.Bookings)
                   .HasForeignKey(r => r.StatusBookingId);

            builder.HasOne(r => r.SystemUser)
                   .WithMany(u => u.RegisteredBookings)
                   .HasForeignKey(r => r.SystemUserId);
        }
    }
}
