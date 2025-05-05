using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities.Hotel;

public class Room : BaseEntity<int>, IAggregateRoot
{
    public int IdHabitacion { get; set; }
    public string Numero { get; set; } = null!;
    public int Piso { get; set; }
    public decimal Precio { get; set; }
    public int Capacidad { get; set; }
    public int IdTipoHabitacion { get; set; }

    public TypeRoom TipoHabitacion { get; set; } = null!;
    public ICollection<Booking> Reservas { get; set; } = new List<Booking>();
}

