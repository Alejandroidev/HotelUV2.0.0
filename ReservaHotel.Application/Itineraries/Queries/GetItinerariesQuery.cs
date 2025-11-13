using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Queries
{
    public record GetItinerariesQuery() : IRequest<CustomWebResponse>;
}