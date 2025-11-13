using Ardalis.Specification;
using ReservaHotel.Domain.Entities;
using System;
namespace ReservaHotel.Application.Rooms.Specifications
{ 
    public sealed class RoomByIdSpec: Specification<Room>
    { 
        public RoomByIdSpec(Guid id){ Query.Where(r=> r.Id==id);} 
    } 
}