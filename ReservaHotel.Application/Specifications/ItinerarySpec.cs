using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using System;

namespace ReservaHotel.Application.Specifications
{
    /// <summary>
    /// Specification for querying Itinerary entities.
    /// </summary>
    public class ItinerarySpec : GeneralSpecification<Guid, Itinerary>
    {
        /// <summary>
        /// Initializes an empty itinerary specification.
        /// </summary>
        public ItinerarySpec() { }

        /// <summary>
        /// Initializes a specification that filters by itinerary identifier.
        /// </summary>
        public ItinerarySpec(Guid id) : base(id)
        {
            Query.Where(i => i.Id == id);
        }

        /// <summary>
        /// Initializes a specification that applies pagination.
        /// </summary>
        public ItinerarySpec(int skip, int take) : base(skip, take)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
