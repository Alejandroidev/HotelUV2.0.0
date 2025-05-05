using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(r => r.IdReserva);
            builder.Property(r => r.FechaCreacion)
                 .HasColumnType("timestamp with time zone")
                 .IsRequired();
            builder.Property(r => r.FechaInicio)
                 .HasColumnType("timestamp with time zone")
                 .IsRequired();
            builder.Property(r => r.FechaFin)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.HasOne(r => r.Cliente)
                   .WithMany(c => c.Reservas)
                   .HasForeignKey(r => r.IdCliente);
            builder.HasOne(r => r.Habitacion)
                   .WithMany(h => h.Reservas)
                   .HasForeignKey(r => r.IdHabitacion);
            builder.HasOne(r => r.EstadoReserva)
                   .WithMany(e => e.Reservas)
                   .HasForeignKey(r => r.IdEstadoReserva);
            builder.HasOne(r => r.UsuarioSistema)
                   .WithMany(u => u.ReservasRegistradas)
                   .HasForeignKey(r => r.IdUsuarioSistema);
        }
    }
}
