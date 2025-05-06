using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities
{
    public class TypeRoom : BaseEntity<int>, IAggregateRoot
    {
        public string TypeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
