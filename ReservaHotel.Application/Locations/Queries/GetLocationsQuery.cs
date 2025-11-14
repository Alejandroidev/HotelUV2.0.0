using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Locations.Queries
{
    /// <summary>
    /// Query to list all locations.
    /// </summary>
    public record GetLocationsQuery() : IRequest<CustomWebResponse>;
}