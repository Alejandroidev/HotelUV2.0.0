using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class ItinerarioConfiguration : IEntityTypeConfiguration<Itinerario>
    {
        public void Configure(EntityTypeBuilder<Itinerario> builder)
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
                   .HasForeignKey<Itinerario>(i => i.IdReserva);
        }
    }
}
