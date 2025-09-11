using AutoMapper;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Application.Common.Dtos;

namespace ReservaHotel.Application.Services
{
    public class ItineraryService : ServiceRead<Itinerary, ItineraryDto, int, ItinerarySpec>, IItineraryService
    {
        public ItineraryService(IRepository<Itinerary> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }

        public Task<CustomWebResponse> Add(ItineraryDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Update(int id, ItineraryDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
