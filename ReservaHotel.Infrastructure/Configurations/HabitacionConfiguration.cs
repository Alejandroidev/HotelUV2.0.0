using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.HasKey(h => h.IdHabitacion);
            builder.Property(h => h.Numero).IsRequired().HasMaxLength(10);
            builder.Property(h => h.Piso).IsRequired();
            builder.Property(h => h.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(h => h.Capacidad).IsRequired();
            builder.HasOne(h => h.TipoHabitacion)
                   .WithMany(t => t.Habitaciones)
                   .HasForeignKey(h => h.IdTipoHabitacion);
        }
    }
}
