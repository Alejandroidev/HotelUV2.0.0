using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelUArcClean.Infrastructure.Configurations
{
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.PickUp).IsRequired();
            builder.Property(i => i.PickDown).IsRequired();
            builder.Property(i => i.Create).IsRequired();

            // Relaciones
            builder.HasOne(i => i.Rooms)
                   .WithMany(r => r.Itinerary)
                   .HasForeignKey(i => i.IdRoom)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Itinerary");
        }
    }
}