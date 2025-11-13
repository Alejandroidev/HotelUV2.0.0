using Ardalis.Specification;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.Employees.Specifications
{
    public sealed class EmployeeByIdSpec : Specification<Employee>
    {
        public EmployeeByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}