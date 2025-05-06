using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities.Hotel;

namespace ReservaHotel.Application.Specifications.Hotel
{
    public class BookingSpec : GeneralSpecification<int, Booking>
    {
        public BookingSpec() { }

        public BookingSpec(int id) : base(id)
        {
            Query.Where(e => e.Id == id);
        }

        public BookingSpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }

        public BookingSpec(string clientName, string roomNumber)
        {
            Query.Where(e => e.Client.FirstName.Contains(clientName) || e.Client.LastName.Contains(clientName))
                .Where(e => e.Room.Number.Contains(roomNumber));
        }

        public BookingSpec(string clientName, string roomNumber, DateTime checkInDate)
        {
            Query.Where(e => e.Client.FirstName.Contains(clientName) || e.Client.LastName.Contains(clientName))
                .Where(e => e.Room.Number.Contains(roomNumber))
                .Where(e => e.Itinerary.CheckInDate == checkInDate);
        }

        public BookingSpec(string clientName, string roomNumber, DateTime checkInDate, DateTime checkOutDate, int skip, int take) : base(skip, take)
        {
            Query.Where(e => e.Client.FirstName.Contains(clientName) || e.Client.LastName.Contains(clientName))
                .Where(e => e.Room.Number.Contains(roomNumber))
                .Where(e => e.Itinerary.CheckInDate == checkInDate && e.Itinerary.CheckOutDate == checkOutDate)
                .Skip(skip).Take(take);
        }

        public BookingSpec(string clientName, string document, int skip, int take) : base(skip, take)
        {
            Query.Where(b => (b.Client.FirstName.Contains(clientName) && b.Client.DocumentNumber == document) || (b.Client.LastName.Contains(clientName) && b.Client.DocumentNumber == document))
                .Skip(skip).Take(take);
        }

        public BookingSpec(string clientName, string roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            Query.Where(e => e.Client.FirstName.Contains(clientName) || e.Client.LastName.Contains(clientName))
                .Where(e => e.Room.Number.Contains(roomNumber))
                .Where(e => e.Itinerary.CheckInDate == checkInDate && e.Itinerary.CheckOutDate == checkOutDate);
        }

    }
}
