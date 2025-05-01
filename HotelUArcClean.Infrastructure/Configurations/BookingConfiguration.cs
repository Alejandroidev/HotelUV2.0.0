using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelUArcClean.Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ValorTotal).IsRequired();

            // Relaciones
            builder.HasOne(b => b.Rooms)
                   .WithMany(r => r.Bookings)
                   .HasForeignKey(b => b.IdRoom)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Client)
                   .WithMany()
                   .HasForeignKey(b => b.IdCliente)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Status)
                   .WithMany(s => s.Booking)
                   .HasForeignKey(b => b.IdStatus)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.IdUsuario)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Itinerary)
                   .WithMany(i => i.Bookings)
                   .HasForeignKey(b => b.IdItinerary)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Booking");
        }
    }
}