using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Application.Common.Dtos;

public class BookingDto : IDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid RoomId { get; set; }
    public Guid StatusBookingId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
}
