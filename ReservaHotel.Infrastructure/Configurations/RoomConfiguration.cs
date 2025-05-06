using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Number).IsRequired().HasMaxLength(10);
            builder.Property(h => h.Floor).IsRequired();
            builder.Property(h => h.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(h => h.Capacity).IsRequired();
            builder.HasOne(h => h.RoomType)
                   .WithMany(t => t.Rooms)
                   .HasForeignKey(h => h.RoomTypeId);
        }
    }
}
