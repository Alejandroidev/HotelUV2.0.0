using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Locations.Commands
{
    public record UpdateLocationCommand(Guid Id, LocationDto Location) : IRequest<CustomWebResponse>;
}