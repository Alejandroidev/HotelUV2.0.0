using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReservaHotel.Domain.Entities;

public class Room : BaseEntity<int>, IAggregateRoot
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public int Floor { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int RoomTypeId { get; set; }


    public TypeRoom RoomType { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

