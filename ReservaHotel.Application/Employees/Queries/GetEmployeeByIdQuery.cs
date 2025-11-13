using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.Employees.Queries
{
    public record GetEmployeeByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}