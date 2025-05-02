using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class TipoHabitacionConfiguration : IEntityTypeConfiguration<TipoHabitacion>
    {
        public void Configure(EntityTypeBuilder<TipoHabitacion> builder)
        {
            builder.HasKey(t => t.IdTipoHabitacion);
            builder.Property(t => t.NombreTipo).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Descripcion).HasMaxLength(200);
        }
    }
}
