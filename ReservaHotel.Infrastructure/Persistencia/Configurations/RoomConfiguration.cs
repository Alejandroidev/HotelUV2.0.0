using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Enums;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Price).HasColumnType("decimal(18,2)");

            // Conversión del enum RoomStatus a string
            builder.Property(r => r.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            // Relación con TypeRoom
            builder.HasOne(r => r.TypeRoom)
                .WithMany(tr => tr.Rooms)
                .HasForeignKey(r => r.TypeRoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Location (AÑADIDA)
            builder.HasOne(r => r.Location)
                .WithMany(l => l.Rooms)
                .HasForeignKey(r => r.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}