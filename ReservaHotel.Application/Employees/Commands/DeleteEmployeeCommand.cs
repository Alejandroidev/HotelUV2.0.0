using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Employees.Commands
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest<CustomWebResponse>;
}