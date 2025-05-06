using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaHotel.Application.Specifications
{
    public class ClientSpec : GeneralSpecification<int, Client>
    {
        public ClientSpec() { }

        public ClientSpec(int id) : base(id)
        {
            Query.Where(e => e.Id == id);
        }

        public ClientSpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }

        public ClientSpec(string firstName, string lastName)
        {
            Query.Where(e => e.FirstName.Contains(firstName) || e.LastName.Contains(lastName));
        }
        public ClientSpec(string firstName, string lastName, int skip, int take) : base(skip, take)
        {
            Query.Where(e => e.FirstName.Contains(firstName) || e.LastName.Contains(lastName))
                .Skip(skip).Take(take);
        }

        public ClientSpec(string firstName, string lastName, string documentNumber)
        {
            Query.Where(e => e.FirstName.Contains(firstName) || e.LastName.Contains(lastName))
                .Where(e => e.DocumentNumber == documentNumber);
        }

        public ClientSpec(string documentNumber)
        {
            Query.Where(e => e.DocumentNumber == documentNumber);
        }

    }
}
