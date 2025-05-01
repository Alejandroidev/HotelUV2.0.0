using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities;

public class Habitacion
{
    public int IdHabitacion { get; set; }
    public string Numero { get; set; } = null!;
    public int Piso { get; set; }
    public decimal Precio { get; set; }
    public int Capacidad { get; set; }
    public int IdTipoHabitacion { get; set; }

    public TipoHabitacion TipoHabitacion { get; set; } = null!;
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

