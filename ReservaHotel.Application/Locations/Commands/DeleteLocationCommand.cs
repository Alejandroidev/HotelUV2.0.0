using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Locations.Commands
{
    public record DeleteLocationCommand(Guid Id) : IRequest<CustomWebResponse>;
}