using AutoMapper;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.General;
using ReservaHotel.Application.Specifications.Hotel;
using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using Serilog;
using System.Net;

namespace ReservaHotel.Application.Services.Hotel
{
    public class BookingService : ServiceRead<Booking, BookingDto, int, BookingSpec>, IBookingService
    {

        public BookingService(IRepository<Booking> entityRepository, IMapper mapper, ILogger logger) : base(entityRepository, mapper, logger)
        {

        }

        /// <summary>
        /// Add a new booking
        /// </summary>
        /// <param name="entityData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<CustomWebResponse> Add(BookingDto entityData, CancellationToken ct = default)
        {
            Booking booking = new Booking
            {
                ClientId = entityData.ClientId,
                RoomId = entityData.RoomId,
                StartDate = entityData.StartDate,
                EndDate = entityData.EndDate,
                StatusBookingId = entityData.StatusBookingId
            };

            await _entityRepository.AddAsync(booking, ct);

            if (booking != null)
            {
                _logger.Information("Added booking Type Collection: '{@entity}'", booking);
                var bookingDto = _mapper.Map<BookingDto>(booking);

                return new CustomWebResponse()
                {
                    ResponseBody = bookingDto
                };
            }

            return new CustomWebResponse(true)
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Server error",
            };
        }

        /// <summary>
        /// Delete a booking
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            var specification = new BookingSpec(id);
            var entity = await _entityRepository.FirstOrDefaultAsync(specification, ct);

            if (entity == null)
                return new CustomWebResponse(true)
                {
                    Message = "Not found",
                };

            await _entityRepository.DeleteAsync(entity, ct);

            if (entity != null)
            {
                _logger.Information("Deleted Booking: {@entity}", entity);
                return new CustomWebResponse();
            }

            return new CustomWebResponse(true)
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Server error",
            };
        }

        /// <summary>
        /// Update a booking
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityData"></param>
        /// <param name="ct"></param>
        /// <returns> CustomWebResponse </returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CustomWebResponse> Update(int id, BookingDto entityData, CancellationToken ct = default)
        {
            var specification = new BookingSpec(id);
            var entity = await _entityRepository.FirstOrDefaultAsync(specification, ct);
            if (entity != null)
            {
                entity.ClientId = entityData.ClientId;
                entity.RoomId = entityData.RoomId;
                entity.StartDate = entityData.StartDate;
                entity.EndDate = entityData.EndDate;
                entity.StatusBookingId = entityData.StatusBookingId;

                await _entityRepository.UpdateAsync(entity, ct);

                _logger.Information("Updated Booking: {@entity}", entity);

                var bookingDto = _mapper.Map<BookingDto>(entity);

                return new CustomWebResponse()
                {
                    ResponseBody = bookingDto
                };
            }
            return new CustomWebResponse(true)
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Server error",
            };
        }
    }
}
