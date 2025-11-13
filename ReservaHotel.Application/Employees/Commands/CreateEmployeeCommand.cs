using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Employees.Commands
{
    public record CreateEmployeeCommand(EmployeeDto Employee) : IRequest<CustomWebResponse>;
}