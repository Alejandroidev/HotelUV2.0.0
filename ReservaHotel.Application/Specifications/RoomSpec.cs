using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Application.Specifications
{
    public class RoomSpec : GeneralSpecification<int, Room>
    {
        public RoomSpec()
        {
        }

        public RoomSpec(int id) : base(id)
        {
            Query.Where(e => e.Id == id)
                .Include(a => a.RoomType);
        }

        public RoomSpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }

        public static RoomSpec GetByType(int roomTypeId)
        {
            var spec = new RoomSpec();
            spec.Query
                .Where(e => e.RoomTypeId == roomTypeId);

            return spec;
        }
    }
}
