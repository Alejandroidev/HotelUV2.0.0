using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Amenities.Commands
{
    public record UpdateAmenityCommand(Guid Id, AmenityDto Amenity) : IRequest<CustomWebResponse>;
}