using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Commands
{
    public record CreateItineraryCommand(ItineraryDto Itinerary) : IRequest<CustomWebResponse>;
}