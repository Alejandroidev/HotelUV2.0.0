using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Commands
{
    public record UpdateItineraryCommand(int Id, ItineraryDto Itinerary) : IRequest<CustomWebResponse>;
}