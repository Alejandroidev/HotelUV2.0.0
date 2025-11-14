using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Locations.Queries
{
    /// <summary>
    /// Query to retrieve a location by identifier.
    /// </summary>
    /// <param name="Id">Location identifier.</param>
    public record GetLocationByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}