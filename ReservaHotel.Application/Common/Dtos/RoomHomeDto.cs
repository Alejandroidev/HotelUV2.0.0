using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Application.Common.Dtos
{
    public class RoomHomeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string LocationName { get; set; }
        public string TypeRoomName { get; set; }
        public List<string> Amenities { get; set; } = new();
    }

}


