using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Amenities.Commands
{
    public record CreateAmenityCommand(AmenityDto Amenity) : IRequest<CustomWebResponse>;
}