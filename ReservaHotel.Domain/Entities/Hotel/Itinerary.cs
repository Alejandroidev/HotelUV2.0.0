using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities.Hotel
{
    public class Itinerary : BaseEntity<int>, IAggregateRoot
    {
        public int IdItinerario { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }

        public Booking Reserva { get; set; } = null!;
    }
}
