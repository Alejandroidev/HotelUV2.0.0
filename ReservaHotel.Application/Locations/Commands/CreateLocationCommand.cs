using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Locations.Commands
{
    public record CreateLocationCommand(LocationDto Location) : IRequest<CustomWebResponse>;
}