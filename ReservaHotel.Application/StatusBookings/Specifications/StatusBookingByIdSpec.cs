using Ardalis.Specification;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.StatusBookings.Specifications
{
    public sealed class StatusBookingByIdSpec : Specification<StatusBooking>
    {
        public StatusBookingByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}