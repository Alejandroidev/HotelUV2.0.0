using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos;
public class StatusBookingDto : IDto
{
    public Guid Id { get; set; }
    public string StatusName { get; set; } = null!;
}