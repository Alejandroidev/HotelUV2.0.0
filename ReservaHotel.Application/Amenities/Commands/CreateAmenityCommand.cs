using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Amenities.Commands
{
    /// <summary>
    /// Command to create a new amenity.
    /// </summary>
    /// <param name="Amenity">Amenity DTO payload.</param>
    public record CreateAmenityCommand(AmenityDto Amenity) : IRequest<CustomWebResponse>;
}