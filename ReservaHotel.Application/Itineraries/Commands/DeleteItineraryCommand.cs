using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Itineraries.Commands
{
    public record DeleteItineraryCommand(Guid Id) : IRequest<CustomWebResponse>;
}