using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;


namespace ReservaHotel.Application.Interfaces.General;

/// <summary>
/// Add service interface
/// </summary>
/// <typeparam name="DTO">DTO class type</typeparam>
public interface IServiceAdd<DTO>
    where DTO : class, IDto
{
    /// <summary>
    /// Add element
    /// </summary>
    /// <param name="entityData">Entity data</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Process result</returns>
    Task<CustomWebResponse> Add(DTO entityData, CancellationToken ct = default);
}