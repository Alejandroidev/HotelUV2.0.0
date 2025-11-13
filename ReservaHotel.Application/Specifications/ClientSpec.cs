using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.Specifications
{
    public class ClientSpec : GeneralSpecification<Guid, Client>
    {
        public ClientSpec() { }
        public ClientSpec(Guid id) : base(id)
        {
            Query.Where(c => c.Id == id);
        }
        public ClientSpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
