using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.StatusBookings.Queries
{
    public record GetStatusBookingByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}