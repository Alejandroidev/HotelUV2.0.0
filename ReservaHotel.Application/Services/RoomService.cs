using AutoMapper;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.General;
using ReservaHotel.Application.Specifications;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ReservaHotel.Application.Common.Dtos;

namespace ReservaHotel.Application.Services
{
    public class RoomService : ServiceRead<Room, RoomDto, int, RoomSpec>, IRoomService
    {
        public RoomService(IRepository<Room> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }

        public Task<CustomWebResponse> Add(RoomDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Update(int id, RoomDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomWebResponse> GetAvailableRooms(bool IsFeatured, CancellationToken ct = default)
        {
            int totalRooms = await _entityRepository.CountAsync(ct);
            RoomSpec roomSpec = new RoomSpec(totalRooms);
            throw new NotImplementedException();
        }
    }
}
