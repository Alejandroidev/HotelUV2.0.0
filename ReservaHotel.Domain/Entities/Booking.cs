using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Entities;

/// <summary>
/// booking
/// </summary>
public class Booking : BaseEntity<int>, IAggregateRoot
{
    /// <summary>
    /// Gets or sets the unique identifier for the booking.
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the room associated with the booking.
    /// </summary>
    public int RoomId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the itinerary associated with the booking.
    /// </summary>
    public int StatusBookingId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the system user who registered the booking.
    /// </summary>
    public int SystemUserId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the booking was created.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets or sets the start date and time of the booking.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date and time of the booking.
    /// </summary>
    public DateTime EndDate { get; set; }

    public Client Client { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public StatusBooking BookingStatus { get; set; } = null!;
    public Itinerary Itinerary { get; set; } = null!;
}
