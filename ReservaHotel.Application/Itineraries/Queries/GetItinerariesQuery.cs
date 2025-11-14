using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Queries
{
    /// <summary>
    /// Query to list all itineraries.
    /// </summary>
    public record GetItinerariesQuery() : IRequest<CustomWebResponse>;
}