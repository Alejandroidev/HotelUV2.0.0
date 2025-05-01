using HotelUColombia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelUArcClean.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired(false);
            builder.Property(u => u.LastName).IsRequired(false);
            builder.Property(u => u.Rol).IsRequired(false);
            builder.Property(u => u.Correo).IsRequired(false);
            builder.Property(u => u.Comments).IsRequired(false);
            builder.Property(u => u.User_Name).IsRequired(false);
            builder.Property(u => u.Password).IsRequired(false);

            // Relaciones
            builder.HasMany(u => u.Bookings)
                   .WithOne(b => b.User)
                   .HasForeignKey(b => b.IdUsuario)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("User");
        }
    }
}