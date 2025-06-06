﻿using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Domain.Dto;

namespace ReservaHotel.Presentacion.Controllers.Rest
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IWebTools _webTools;
        private readonly IClientService _entityService;


        public ClientController(IWebTools webTools, IClientService entityService)
        {
            _webTools = webTools;
            _entityService = entityService;
        }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            var response = await _entityService.Get(id, ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Get All entities
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _entityService.GetAll(ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="clientDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPost()]
        public async Task<IActionResult> Post(ClientDto clientDto, CancellationToken ct)
        {
            var response = await _entityService.Add(clientDto, ct);
            return _webTools.CustomResponse(response);
        }

        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="clientDto">Entity data</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Selected entity data</returns>
        [HttpPut()]
        public async Task<IActionResult> Put(int id, ClientDto clientDto, CancellationToken ct)
        {
            var response = await _entityService.Update(id, clientDto, ct);
            return _webTools.CustomResponse(response);
        }


    }
}
