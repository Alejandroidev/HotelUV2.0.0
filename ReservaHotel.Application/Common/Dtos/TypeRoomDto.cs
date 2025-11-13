using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos
{
    public class TypeRoomDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
