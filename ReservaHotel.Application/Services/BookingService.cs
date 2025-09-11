using AutoMapper;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.General;
using ReservaHotel.Application.Specifications.Hotel;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;
using ReservaHotel.Application.Common.Dtos;

namespace ReservaHotel.Application.Services
{
    public class BookingService : ServiceRead<Booking, BookingDto, int, BookingSpec>, IBookingService
    {

        public BookingService(IRepository<Booking> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {

        }

        public Task<CustomWebResponse> Add(BookingDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Update(int id, BookingDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
