using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Itineraries.Commands
{
    /// <summary>
    /// Command to update an itinerary by id.
    /// </summary>
    /// <param name="Id">Itinerary identifier.</param>
    /// <param name="Itinerary">Updated itinerary DTO.</param>
    public record UpdateItineraryCommand(Guid Id, ItineraryDto Itinerary) : IRequest<CustomWebResponse>;
}