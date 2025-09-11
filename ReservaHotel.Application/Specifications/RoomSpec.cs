using Ardalis.Specification;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Enums;
using System;
using System.Linq;

namespace ReservaHotel.Application.Specifications
{
    public class RoomSpec : GeneralSpecification<Guid, Room>
    {
        private RoomSpec() { }

        // Constructor simple por Id (si lo usas)
        public RoomSpec(Guid id) : base(id) { }

        // Constructor por IsFeatured (sencillo)
        public RoomSpec(bool isFeatured)
        {
            Query.Where(r => r.IsFeatured == isFeatured);
        }

        /// <summary>
        /// sede bogota - medellin
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public static RoomSpec ForLocation(Guid locationId)
        {
            var spec = new RoomSpec();
            spec.Query.Where(r => r.LocationId == locationId);
            return spec;
        }

        /// <summary>
        /// filtros que iria en front - capacidad minima
        /// </summary>
        /// <param name="minCapacity"></param>
        /// <returns></returns>
        public static RoomSpec ForMinCapacity(int minCapacity)
        {
            var spec = new RoomSpec();
            spec.Query.Where(r => r.Capacity >= minCapacity);
            return spec;
        }


        public static RoomSpec ForPriceRange(decimal minPrice, decimal maxPrice)
        {
            var spec = new RoomSpec();
            spec.Query.Where(r => r.Price >= minPrice && r.Price <= maxPrice);
            return spec;
        }

        public static RoomSpec ForStatus(RoomStatus status)
        {
            var spec = new RoomSpec();
            spec.Query.Where(r => r.Status == status);
            return spec;
        }

        public static RoomSpec ForType(Guid typeRoomId)
        {
            var spec = new RoomSpec();
            spec.Query.Where(r => r.TypeRoomId == typeRoomId);
            return spec;
        }

        // -------------------------
        // MÉTODOS CON INCLUDES (para evitar N+1)
        // -------------------------

        /// <summary>
        /// Devuelve rooms filtradas por IsFeatured e incluye relaciones necesarias para mostrar en Home:
        /// Location, TypeRoom, RoomAmenities -> Amenity.
        /// Uso recomendado para el Home: evita N+1.
        /// </summary>
        public static RoomSpec ForFeaturedWithIncludes(bool isFeatured)
        {
            var spec = new RoomSpec();
            spec.Query
                .Where(r => r.IsFeatured == isFeatured)
                .Include(r => r.Location)
                .Include(r => r.TypeRoom)
                .Include(r => r.RoomAmenities)           // colección puente
                    .ThenInclude(ra => ra.Amenity);     // navegar a Amenity (si existe)

            return spec;
        }


        
        /// <summary>
        /// Versión combinada con includes: acepta filtros opcionales y agrega Includes para las relaciones comunes.
        /// Útil para endpoints de búsqueda que también necesitan detalles relacionados.
        /// </summary>
        public static RoomSpec ForSearchWithIncludes(Guid? locationId = null,
                                                     bool? isFeatured = null,
                                                     int? minCapacity = null,
                                                     decimal? minPrice = null,
                                                     decimal? maxPrice = null,
                                                     RoomStatus? status = null,
                                                     Guid? typeRoomId = null)
        {
            var spec = new RoomSpec();

            if (locationId.HasValue) 
                spec.Query.Where(r => r.LocationId == locationId.Value);

            if (isFeatured.HasValue) 
                spec.Query.Where(r => r.IsFeatured == isFeatured.Value);

            if (minCapacity.HasValue) 
                spec.Query.Where(r => r.Capacity >= minCapacity.Value);

            if (minPrice.HasValue && maxPrice.HasValue)
                spec.Query.Where(r => r.Price >= minPrice.Value && r.Price <= maxPrice.Value);

            else if (minPrice.HasValue)
                spec.Query.Where(r => r.Price >= minPrice.Value);

            else if (maxPrice.HasValue)
                spec.Query.Where(r => r.Price <= maxPrice.Value);

            if (status.HasValue) 
                spec.Query.Where(r => r.Status == status.Value);

            if (typeRoomId.HasValue) 
                spec.Query.Where(r => r.TypeRoomId == typeRoomId.Value);

            // includes para evitar N+1 cuando se requieran detalles
            spec.Query
                .Include(r => r.Location)
                .Include(r => r.TypeRoom)
                .Include(r => r.RoomAmenities)
                    .ThenInclude(ra => ra.Amenity);

            return spec;
        }
    }
}
