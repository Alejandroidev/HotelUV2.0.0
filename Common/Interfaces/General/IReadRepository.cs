using Ardalis.Specification;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Application.Interfaces.General;

/// <summary>
/// Read-only repository interface
/// </summary>
/// <typeparam name="T">Entity class type</typeparam>
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{ }