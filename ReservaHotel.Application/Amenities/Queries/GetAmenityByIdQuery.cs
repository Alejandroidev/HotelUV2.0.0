using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Amenities.Queries
{
    /// <summary>
    /// Query to retrieve an amenity by its identifier.
    /// </summary>
    /// <param name="Id">Amenity identifier.</param>
    public record GetAmenityByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}