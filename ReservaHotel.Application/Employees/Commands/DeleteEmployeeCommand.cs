using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Employees.Commands
{
    /// <summary>
    /// Command to delete an employee by identifier.
    /// </summary>
    /// <param name="Id">Employee identifier.</param>
    public record DeleteEmployeeCommand(Guid Id) : IRequest<CustomWebResponse>;
}