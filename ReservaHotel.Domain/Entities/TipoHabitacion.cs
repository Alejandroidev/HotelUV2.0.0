using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities
{
    public class TipoHabitacion
    {
        public int IdTipoHabitacion { get; set; }
        public string NombreTipo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
    }
}
