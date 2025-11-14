using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Amenities.Commands
{
    /// <summary>
    /// Command to delete an amenity by identifier.
    /// </summary>
    /// <param name="Id">Amenity identifier.</param>
    public record DeleteAmenityCommand(Guid Id) : IRequest<CustomWebResponse>;
}