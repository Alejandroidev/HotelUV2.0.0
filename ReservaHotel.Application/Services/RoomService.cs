using AutoMapper;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Application.Specifications.Hotel;
using ReservaHotel.Domain.Dto;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Application.Services
{
    public class RoomService : ServiceRead<Room, RoomDto, int, RoomSpec>, IRoomService
    {
        public RoomService(IRepository<Room> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }

        public async Task<CustomWebResponse> Add(RoomDto entityData, CancellationToken ct = default)
        {
            Room room = new()
            {
                Capacity = entityData.Capacity,
                RoomTypeId = entityData.RoomTypeId,
                Price = entityData.Price,
                Floor = entityData.Floor,
                Number = entityData.Number
            };

            room = await _entityRepository.AddAsync(room, ct);

            if (room != null)
            {
                var roomDto = _mapper.Map<BookingDto>(room);

                return new CustomWebResponse()
                {
                    ResponseBody = roomDto
                };
            }

            return new CustomWebResponse(true)
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Server error",
            };
        }

        public async Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            var roomSpec = new RoomSpec(id);
            var room = await _entityRepository.FirstOrDefaultAsync(roomSpec, ct);
            if (room != null)
            {
                await _entityRepository.DeleteAsync(room, ct);

                return new CustomWebResponse();

            }
            return new CustomWebResponse()
            {
                Message = "not found",
                ResponseBody = "not found",
                StatusCode = HttpStatusCode.NotFound,
                Success = false

            };

        }

        public async Task<CustomWebResponse> Update(int id, RoomDto entityData, CancellationToken ct = default)
        {
            var roomSpec = new RoomSpec(id);
            var room = await _entityRepository.FirstOrDefaultAsync(roomSpec, ct);

            if (room != null)
            {
                room.Number = entityData.Number;
                room.Price = entityData.Price;
                room.Floor = entityData.Floor;
                room.RoomTypeId = entityData.RoomTypeId;
                room.Capacity = entityData.Capacity;
                await _entityRepository.UpdateAsync(room, ct);
                var roomDto = _mapper.Map<BookingDto>(room);

                return new CustomWebResponse()
                {
                    ResponseBody = roomDto
                };
            }

            return new CustomWebResponse()
            {
                Message = "not found",
                ResponseBody = "not found",
                StatusCode = HttpStatusCode.NotFound,
                Success = false

            };
        }
    }
}
