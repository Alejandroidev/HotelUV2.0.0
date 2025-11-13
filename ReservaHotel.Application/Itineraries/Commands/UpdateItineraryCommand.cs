using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Itineraries.Commands
{
    public record UpdateItineraryCommand(Guid Id, ItineraryDto Itinerary) : IRequest<CustomWebResponse>;
}