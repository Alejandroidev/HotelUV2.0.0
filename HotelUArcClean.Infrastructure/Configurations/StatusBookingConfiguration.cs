using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelUArcClean.Infrastructure.Configurations
{
    public class StatusBookingConfiguration : IEntityTypeConfiguration<StatusBooking>
    {
        public void Configure(EntityTypeBuilder<StatusBooking> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Status).IsRequired();

            builder.ToTable("StatusBooking");
        }
    }
}