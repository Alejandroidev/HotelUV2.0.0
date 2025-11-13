using Ardalis.Specification;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.TypeRooms.Specifications
{
    public sealed class TypeRoomByIdSpec : Specification<TypeRoom>
    {
        public TypeRoomByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}