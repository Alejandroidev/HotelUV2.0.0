using Ardalis.Specification.EntityFrameworkCore;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Interfaces;
using ReservaHotel.Infrastructure.Data;

namespace ReservaHotel.Infrastructure;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    public EfRepository(HotelDbContext dbContext) : base(dbContext)
    { }
}