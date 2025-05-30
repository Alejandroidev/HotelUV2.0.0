namespace ReservaHotel.Domain.Entities.Base;

/// <summary>
/// Generic base entity
/// </summary>
/// <typeparam name="T">Identifier type</typeparam>
public abstract class BaseEntity<T>
    where T : notnull
{
    /// <summary>
    /// Base entity identifier
    /// </summary>
    public virtual T Id { get; protected set; }
}