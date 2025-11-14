using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Amenities.Queries
{
    /// <summary>
    /// Query to list all amenities.
    /// </summary>
    public record GetAmenitiesQuery() : IRequest<CustomWebResponse>;
}