using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Interfaces.General;

/// <summary>
/// Read enum service interface 
/// </summary>
public interface IServiceReadEnum<TEnum>
    where TEnum : struct
{
    /// <summary>
    /// Get all elements
    /// </summary>
    /// <returns>Process result</returns>
    CustomWebResponse GetAll();
}