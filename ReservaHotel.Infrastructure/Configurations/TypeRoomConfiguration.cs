using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class TypeRoomConfiguration : IEntityTypeConfiguration<TypeRoom>
    {
        public void Configure(EntityTypeBuilder<TypeRoom> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TypeName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(200);
        }
    }
}
