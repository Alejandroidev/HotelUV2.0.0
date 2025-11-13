using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.Specifications.Hotel
{
    public class BookingSpec : GeneralSpecification<Guid, Booking>
    {
        public BookingSpec() { }
        public BookingSpec(Guid id) : base(id)
        {
            Query.Where(b => b.Id == id);
        }
        public BookingSpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
