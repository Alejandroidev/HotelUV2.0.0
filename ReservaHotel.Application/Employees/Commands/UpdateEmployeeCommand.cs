using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Employees.Commands
{
    /// <summary>
    /// Command to update an existing employee.
    /// </summary>
    /// <param name="Id">Employee identifier.</param>
    /// <param name="Employee">Updated employee DTO.</param>
    public record UpdateEmployeeCommand(Guid Id, EmployeeDto Employee) : IRequest<CustomWebResponse>;
}