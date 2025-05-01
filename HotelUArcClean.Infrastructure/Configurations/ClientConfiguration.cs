using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelUArcClean.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Phone).IsRequired();

            builder.ToTable("Client");
        }
    }
}