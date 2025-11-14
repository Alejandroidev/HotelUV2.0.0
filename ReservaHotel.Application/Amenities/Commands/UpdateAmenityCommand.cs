using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Amenities.Commands
{
    /// <summary>
    /// Command to update an amenity by identifier.
    /// </summary>
    /// <param name="Id">Amenity identifier.</param>
    /// <param name="Amenity">Updated amenity DTO.</param>
    public record UpdateAmenityCommand(Guid Id, AmenityDto Amenity) : IRequest<CustomWebResponse>;
}