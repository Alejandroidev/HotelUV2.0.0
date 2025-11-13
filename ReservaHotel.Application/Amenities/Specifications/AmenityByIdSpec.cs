using Ardalis.Specification;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.Amenities.Specifications
{
    public sealed class AmenityByIdSpec : Specification<Amenity>
    {
        public AmenityByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}