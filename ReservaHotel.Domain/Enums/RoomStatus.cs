namespace ReservaHotel.Domain.Enums
{
    /// <summary>
    /// Defines the possible operational statuses for a hotel room.
    /// </summary>
    public enum RoomStatus
    {
        /// <summary>
        /// The room is available for booking.
        /// </summary>
        Available,

        /// <summary>
        /// The room is currently occupied by a guest.
        /// </summary>
        Occupied,

        /// <summary>
        /// The room is currently being cleaned.
        /// </summary>
        Cleaning,

        /// <summary>
        /// The room is temporarily out of service for maintenance.
        /// </summary>
        OutOfService
    }
}