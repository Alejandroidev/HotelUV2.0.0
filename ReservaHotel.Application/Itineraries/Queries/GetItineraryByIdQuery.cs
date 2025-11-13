using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Queries
{
    public record GetItineraryByIdQuery(int Id) : IRequest<CustomWebResponse>;
}