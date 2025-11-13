using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Employees.Commands
{
    public record UpdateEmployeeCommand(Guid Id, EmployeeDto Employee) : IRequest<CustomWebResponse>;
}