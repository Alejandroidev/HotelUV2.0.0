using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos
{
    public class UserDto : IDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public bool IsActive { get; set; }
        public Guid EmployeeId { get; set; }
        // For demo only: expose password fields carefully; avoid in production
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    }
}