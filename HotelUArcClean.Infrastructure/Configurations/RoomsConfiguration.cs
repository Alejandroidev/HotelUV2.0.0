using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelUArcClean.Infrastructure.Configurations
{
    public class RoomsConfiguration : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            // Definir la clave primaria
            builder.HasKey(r => r.Id);

            // Configurar las propiedades
            builder.Property(r => r.Bathroom).IsRequired();
            builder.Property(r => r.Category).IsRequired();
            builder.Property(r => r.Freezer).IsRequired();
            builder.Property(r => r.Image)
                   .HasMaxLength(255)
                   .IsRequired();
            builder.Property(r => r.NumberBeds).IsRequired();
            builder.Property(r => r.Price).IsRequired();
            builder.Property(r => r.TV).IsRequired();

            // Configurar las relaciones
            builder.HasMany(r => r.Bookings)
                   .WithOne(b => b.Rooms)
                   .HasForeignKey(b => b.IdRoom)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Itinerary)
                   .WithOne(i => i.Rooms)
                   .HasForeignKey(i => i.IdRoom)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configurar el nombre de la tabla
            builder.ToTable("Rooms");
        }
    }
}