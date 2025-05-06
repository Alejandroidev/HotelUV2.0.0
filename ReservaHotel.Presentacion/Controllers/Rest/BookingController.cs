
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Application.Interfaces;
using ReservaHotel.Domain.Dto;

namespace ReservaHotel.Presentacion.Controllers.Rest;

[ApiController]
[Route("booking")]
public class BookingController : ControllerBase
{
    private readonly IWebTools _webTools;
    private readonly IBookingService _entityService;

    public BookingController(IWebTools webTools, IBookingService entityService)
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
    /// Add Booking
    /// </summary>
    /// <param name="bookingDto">Entity data</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Selected entity data</returns>
    [HttpPost()]
    public async Task<IActionResult> Post(BookingDto bookingDto ,CancellationToken ct)
    {
        var response = await _entityService.Add(bookingDto ,ct);
        return _webTools.CustomResponse(response);
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <param name="bookingDto">Entity data</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Selected entity data</returns>
    [HttpPut()]
    public async Task<IActionResult> Put(int id, BookingDto bookingDto, CancellationToken ct)
    {
        var response = await _entityService.Update(id, bookingDto, ct);
        return _webTools.CustomResponse(response);
    }

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Selected entity data</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var response = await _entityService.Delete(id, ct);
        return _webTools.CustomResponse(response);
    }

}