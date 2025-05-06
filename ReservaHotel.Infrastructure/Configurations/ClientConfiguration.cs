using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Phone).HasMaxLength(15);
            builder.Property(c => c.DocumentNumber).IsRequired().HasMaxLength(20);
        }
    }
}
