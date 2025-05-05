using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities.Hotel
{
    public class TypeRoom : BaseEntity<int>, IAggregateRoot
    {
        public int IdTipoHabitacion { get; set; }
        public string NombreTipo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public ICollection<Room> Habitaciones { get; set; } = new List<Room>();
    }
}
