using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Infrastructure.Configurations
{
    public class UsuarioSistemaConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(u => u.IdUsuarioSistema);
            builder.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Rol).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.ClaveHash).IsRequired();
        }
    }
}
