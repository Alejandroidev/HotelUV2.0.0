using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Application.Interfaces.General;

/// <summary>
/// CRUD service interface 
/// </summary>
/// <typeparam name="DTO">DTO class type</typeparam>
/// <typeparam name="ET">Entity identifier type</typeparam>
public interface IServiceCrud<DTO, ET> : IServiceAdd<DTO>, IServiceRead<DTO, ET>, IServiceUpdate<DTO, ET>, IServiceDelete<ET>
    where DTO : class, IDto
    where ET : notnull
{ }