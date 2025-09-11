using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class TypeRoomConfiguration : IEntityTypeConfiguration<TypeRoom>
    {
        public void Configure(EntityTypeBuilder<TypeRoom> builder)
        {
            builder.ToTable("TypeRoom");
            builder.HasKey(tr => tr.Id);
        }
    }
}
