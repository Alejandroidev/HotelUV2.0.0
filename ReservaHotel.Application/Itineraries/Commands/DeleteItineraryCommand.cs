using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Itineraries.Commands
{
    public record DeleteItineraryCommand(int Id) : IRequest<CustomWebResponse>;
}