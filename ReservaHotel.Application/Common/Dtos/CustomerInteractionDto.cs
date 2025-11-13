using ReservaHotel.Domain.Enums;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos
{
    public class CustomerInteractionDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime InteractionDate { get; set; }
        public InteractionType InteractionType { get; set; }
        public string Notes { get; set; } = null!;
        public Guid? SystemUserId { get; set; }
    }
}