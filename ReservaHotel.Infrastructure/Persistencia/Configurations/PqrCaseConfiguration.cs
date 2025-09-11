using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Enums;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class PqrCaseConfiguration : IEntityTypeConfiguration<PqrCase>
    {
        public void Configure(EntityTypeBuilder<PqrCase> builder)
        {
            builder.ToTable("PqrCase");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PqrType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            // Relación con Client
            builder.HasOne(p => p.Client)
                .WithMany() // Un cliente puede tener muchos PQR, pero no necesitamos la colección en Client
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación opcional con Booking
            builder.HasOne(p => p.Booking)
                .WithMany()
                .HasForeignKey(p => p.BookingId)
                .IsRequired(false) // La relación es opcional
                .OnDelete(DeleteBehavior.SetNull); // Si se borra la reserva, el PQR no se borra
        }
    }
}