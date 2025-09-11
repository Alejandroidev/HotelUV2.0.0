using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.ToTable("Itinerary");
            builder.HasKey(i => i.Id);

            // Relación uno a uno con Booking
            builder.HasOne(i => i.Booking)
                .WithOne(b => b.Itinerary)
                .HasForeignKey<Itinerary>(i => i.BookingId);
        }
    }
}