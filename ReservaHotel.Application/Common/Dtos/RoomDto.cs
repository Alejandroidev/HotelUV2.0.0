using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos;

public class RoomDto : IDto
{
    public Guid Id { get; set; }
    public Guid TypeRoomId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public bool IsFeatured { get; set; }
    public Guid LocationId { get; set; }
}

