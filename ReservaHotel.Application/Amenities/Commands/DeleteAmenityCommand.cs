using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Amenities.Commands
{
    public record DeleteAmenityCommand(Guid Id) : IRequest<CustomWebResponse>;
}