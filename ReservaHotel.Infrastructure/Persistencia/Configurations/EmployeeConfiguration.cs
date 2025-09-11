using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Infrastructure.Persistencia.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.NationalId).IsRequired().HasMaxLength(20);
            builder.HasIndex(e => e.NationalId).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();

            // Relación uno a uno opcional con User.
            // Un empleado (Employee) puede tener un usuario (User) o no.
            // Un usuario (User) DEBE estar asociado a un empleado.
            // La clave foránea está en la tabla User.
            builder.HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<User>(u => u.EmployeeId);
        }
    }
}