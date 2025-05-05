using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class EstadoReservaConfiguration : IEntityTypeConfiguration<StatusBooking>
    {
        public void Configure(EntityTypeBuilder<StatusBooking> builder)
        {
            builder.HasKey(e => e.IdEstadoReserva);
            builder.Property(e => e.NombreEstado).IsRequired().HasMaxLength(50);
        }
    }
}
