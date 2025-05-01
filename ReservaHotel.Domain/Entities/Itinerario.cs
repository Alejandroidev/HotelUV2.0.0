using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities
{
    public class Itinerario
    {
        public int IdItinerario { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }

        public Reserva Reserva { get; set; } = null!;
    }
}
