using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Itineraries.Queries
{
    /// <summary>
    /// Query to retrieve an itinerary by its identifier.
    /// </summary>
    /// <param name="Id">Itinerary identifier.</param>
    public record GetItineraryByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}