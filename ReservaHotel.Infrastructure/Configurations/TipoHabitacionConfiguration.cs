using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class TipoHabitacionConfiguration : IEntityTypeConfiguration<TypeRoom>
    {
        public void Configure(EntityTypeBuilder<TypeRoom> builder)
        {
            builder.HasKey(t => t.IdTipoHabitacion);
            builder.Property(t => t.NombreTipo).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Descripcion).HasMaxLength(200);
        }
    }
}
