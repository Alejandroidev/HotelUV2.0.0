using System.Linq.Expressions;
using ReservaHotel.Domain.Entities;

namespace ReservaHotel.Application.Specifications
{
    public class EstadoReservaByNombreSpecification
    {
        public static Expression<Func<EstadoReserva, bool>> IsMatchingNombre(string nombre)
        {
            return estado => estado.NombreEstado.Contains(nombre);
        }
    }
}
