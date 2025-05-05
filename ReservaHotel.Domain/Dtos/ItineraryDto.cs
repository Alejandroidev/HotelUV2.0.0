using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Domain.Dto
{
    public class ItineraryDto : IDto
    {
        public int IdItinerario { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public BookingDto Reserva { get; set; } = null!;
    }
}
