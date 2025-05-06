using AutoMapper;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Services
{
    public class ItineraryService : ServiceRead<Itinerary, ItineraryDto, int, ItinerarySpec>, IItineraryService
    {
        public ItineraryService(IRepository<Itinerary> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }

        public async Task<CustomWebResponse> Add(ItineraryDto entityData, CancellationToken ct = default)
        {
            Itinerary itinerary = new Itinerary
            {
                BookingId = entityData.BookingId,
                CheckInDate = entityData.CheckInDate,
                CheckOutDate = entityData.CheckOutDate
            };

            // Map other properties as needed
            await _entityRepository.AddAsync(itinerary, ct);

            if (itinerary != null)
            {
                var itineraryDto = _mapper.Map<ItineraryDto>(itinerary);
                return new CustomWebResponse()
                {
                    ResponseBody = itineraryDto
                };
            }

            return new CustomWebResponse(true)
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Server error",
            };
        }

        public async Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            var itinerarySpec = new ItinerarySpec(id);
            var itinerary = await _entityRepository.FirstOrDefaultAsync(itinerarySpec, ct);

            if (itinerary != null)
            {
                await _entityRepository.DeleteAsync(itinerary, ct);
                return new CustomWebResponse()
                {
                    ResponseBody = itinerary
                };
            }
            return new CustomWebResponse(true)
            {
                Message = "Not found",
            };
        }

        public async Task<CustomWebResponse> Update(int id, ItineraryDto entityData, CancellationToken ct = default)
        {
            var itinerarySpec = new ItinerarySpec(id);
            var itinerary = await _entityRepository.FirstOrDefaultAsync(itinerarySpec, ct);
            if (itinerary != null)
            {
                itinerary.BookingId = entityData.BookingId;
                itinerary.CheckInDate = entityData.CheckInDate;
                itinerary.CheckOutDate = entityData.CheckOutDate;
                await _entityRepository.UpdateAsync(itinerary, ct);
                return new CustomWebResponse()
                {
                    ResponseBody = itinerary
                };
            }
            return new CustomWebResponse(true)
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Server error",
            };
        }
    }
}
