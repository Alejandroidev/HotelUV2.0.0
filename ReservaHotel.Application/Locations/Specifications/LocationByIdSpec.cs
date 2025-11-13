using Ardalis.Specification;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.Locations.Specifications
{
    public sealed class LocationByIdSpec : Specification<Location>
    {
        public LocationByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}