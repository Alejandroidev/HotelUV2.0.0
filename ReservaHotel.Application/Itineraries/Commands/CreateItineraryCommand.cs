using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Commands
{
    /// <summary>
    /// Command to create a new itinerary.
    /// </summary>
    /// <param name="Itinerary">Itinerary DTO payload.</param>
    public record CreateItineraryCommand(ItineraryDto Itinerary) : IRequest<CustomWebResponse>;
}