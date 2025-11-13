using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos
{
    public class ClientDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
