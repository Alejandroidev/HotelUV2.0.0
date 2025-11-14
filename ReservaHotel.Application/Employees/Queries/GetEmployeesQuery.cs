using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Employees.Queries
{
    /// <summary>
    /// Query to list all employees.
    /// </summary>
    public record GetEmployeesQuery() : IRequest<CustomWebResponse>;
}