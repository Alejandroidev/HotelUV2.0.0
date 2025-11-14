using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Itineraries.Commands
{
    /// <summary>
    /// Command to delete an itinerary by its identifier.
    /// </summary>
    /// <param name="Id">Itinerary identifier.</param>
    public record DeleteItineraryCommand(Guid Id) : IRequest<CustomWebResponse>;
}