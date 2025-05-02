using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class EstadoReservaConfiguration : IEntityTypeConfiguration<EstadoReserva>
    {
        public void Configure(EntityTypeBuilder<EstadoReserva> builder)
        {
            builder.HasKey(e => e.IdEstadoReserva);
            builder.Property(e => e.NombreEstado).IsRequired().HasMaxLength(50);
        }
    }
}
