using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Locations.Queries
{
    public record GetLocationByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}