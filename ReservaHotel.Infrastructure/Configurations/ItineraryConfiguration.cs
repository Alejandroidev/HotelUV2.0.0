using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.CheckInDate)
                .HasColumnType("timestamp with time zone")
                .IsRequired();
            builder.Property(i => i.CheckOutDate)
                .HasColumnType("timestamp with time zone").
                IsRequired();

            builder.HasOne(i => i.Booking)
                   .WithOne(r => r.Itinerary)
                   .HasForeignKey<Itinerary>(i => i.BookingId);
        }
    }
}
