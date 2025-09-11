using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class StatusBookingConfiguration : IEntityTypeConfiguration<StatusBooking>
    {
        public void Configure(EntityTypeBuilder<StatusBooking> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.StatusName).IsRequired().HasMaxLength(50);
        }
    }
}
