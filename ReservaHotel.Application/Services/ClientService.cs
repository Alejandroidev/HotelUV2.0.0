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
    /// <summary>
    /// Service for client management
    /// </summary>
    public class ClientService : ServiceRead<Client, ClientDto, int, ClientSpec>, IClientService
    {
        /// <summary>
        /// Initialize service
        /// </summary>
        /// <param name="entityRepository"></param>
        /// <param name="mapper"></param>
        public ClientService(IRepository<Client> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {

        }

        public Task<CustomWebResponse> Add(ClientDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CustomWebResponse> Update(int id, ClientDto entityData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
