using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CreationDate)
                .HasColumnName("creation_date")
                 .HasColumnType("timestamp with time zone")
                 .IsRequired();

            builder.Property(r => r.StartDate)
                .HasColumnName("start_date")
                 .HasColumnType("timestamp with time zone")
                 .IsRequired();

            builder.Property(r => r.EndDate)
                .HasColumnName("end_date")
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

        }
    }
}
