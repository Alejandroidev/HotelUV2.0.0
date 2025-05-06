using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Application.Specifications
{
    public class ItinerarySpec : GeneralSpecification<int, Itinerary>
    {
        public ItinerarySpec() { }
        public ItinerarySpec(int id) : base(id)
        {
            Query.Where(e => e.Id == id)
                .Include(a => a.Booking);
        }
        public ItinerarySpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }
        public ItinerarySpec(DateTime checkInDate, DateTime checkOutDate)
        {
            Query.Where(e => e.CheckInDate == checkInDate && e.CheckOutDate == checkOutDate);
        }
        public ItinerarySpec(DateTime checkInDate, DateTime checkOutDate, int skip, int take) : base(skip, take)
        {
            Query.Where(e => e.CheckInDate == checkInDate && e.CheckOutDate == checkOutDate)
                .Skip(skip).Take(take);
        }

        public static ItinerarySpec GetByBooking(int bookingId)
        {
            var spec = new ItinerarySpec();
            spec.Query
                .Where(e => e.BookingId == bookingId);

            return spec;
        }


    }
}
