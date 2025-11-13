using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Itineraries.Queries
{
    public record GetItineraryByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}