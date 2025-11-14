using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Employees.Commands
{
    /// <summary>
    /// Command to create a new employee.
    /// </summary>
    /// <param name="Employee">Employee DTO payload.</param>
    public record CreateEmployeeCommand(EmployeeDto Employee) : IRequest<CustomWebResponse>;
}