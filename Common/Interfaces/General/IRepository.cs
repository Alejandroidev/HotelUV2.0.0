using Ardalis.Specification;
using ReservaHotel.Domain.Interfaces;

namespace ReservaHotel.Application.Interfaces.General;

/// <summary>
/// General repository interface
/// </summary>
/// <typeparam name="T">Entity class type</typeparam>
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{ }