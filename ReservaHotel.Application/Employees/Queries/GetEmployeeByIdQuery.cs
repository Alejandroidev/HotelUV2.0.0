using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Employees.Queries
{
    /// <summary>
    /// Query to retrieve an employee by identifier.
    /// </summary>
    /// <param name="Id">Employee identifier.</param>
    public record GetEmployeeByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}