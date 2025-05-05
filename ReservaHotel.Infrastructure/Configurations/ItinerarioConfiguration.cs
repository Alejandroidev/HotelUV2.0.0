using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class ItinerarioConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(i => i.IdItinerario);
            builder.Property(i => i.FechaEntrada)
                .HasColumnType("timestamp with time zone")
                .IsRequired();
            builder.Property(i => i.FechaSalida)
                .HasColumnType("timestamp with time zone").
                IsRequired();

            builder.HasOne(i => i.Reserva)
                   .WithOne(r => r.Itinerario)
                   .HasForeignKey<Itinerary>(i => i.IdReserva);
        }
    }
}
