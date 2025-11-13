using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Amenities.Queries
{
    public record GetAmenityByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}