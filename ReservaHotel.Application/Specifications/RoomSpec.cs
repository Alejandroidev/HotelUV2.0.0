using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using System;
using Ardalis.Specification;

namespace ReservaHotel.Application.Specifications
{
    public class RoomSpec : GeneralSpecification<Guid, Room>
    {
        public RoomSpec() { }
        public RoomSpec(Guid id) : base(id)
        {
            Query.Where(r => r.Id == id);
        }
        public RoomSpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
