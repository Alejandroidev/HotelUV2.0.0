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

        /// <summary>
        /// Add a new client
        /// </summary>
        /// <param name="entityData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<CustomWebResponse> Add(ClientDto entityData, CancellationToken ct = default)
        {
            Client client = new Client
            {
                FirstName = entityData.FirstName,
                LastName = entityData.LastName,
                Email = entityData.Email,
                Phone = entityData.Phone,
                DocumentNumber = entityData.DocumentNumber
            };

            await _entityRepository.AddAsync(client, ct);

            if (client != null)
            {
                var clientDto = _mapper.Map<ClientDto>(client);
                return new CustomWebResponse()
                {
                    ResponseBody = clientDto
                };
            }

            return new CustomWebResponse(true)
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Server error",
            };

        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<CustomWebResponse> Delete(int id, CancellationToken ct = default)
        {
            var clientSpec = new ClientSpec(id);
            var client = await _entityRepository.FirstOrDefaultAsync(clientSpec, ct);
            if (client != null)
            {
                await _entityRepository.DeleteAsync(client);
                return new CustomWebResponse()
                {
                    ResponseBody = client
                };
            }
            return new CustomWebResponse(true)
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "Not found",
            };
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<CustomWebResponse> Update(int id, ClientDto entityData, CancellationToken ct = default)
        {
            var clientSpec = new ClientSpec(id);
            var client = await _entityRepository.FirstOrDefaultAsync(clientSpec, ct);
            if (client != null)
            {
                client.FirstName = entityData.FirstName;
                client.LastName = entityData.LastName;
                client.Email = entityData.Email;
                client.Phone = entityData.Phone;
                client.DocumentNumber = entityData.DocumentNumber;
                await _entityRepository.UpdateAsync(client, ct);
                var clientDto = _mapper.Map<ClientDto>(client);
                return new CustomWebResponse()
                {
                    ResponseBody = clientDto
                };
            }
            return new CustomWebResponse(true)
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "Not found",
            };
        }
    }
}
