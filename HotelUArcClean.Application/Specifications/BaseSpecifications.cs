using System;
using System.Linq.Expressions;

namespace HotelUColombia.Models
{
    /// <summary>
    /// Clase base para especificaciones que permite construir consultas dinámicas.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad para la especificación.</typeparam>
    public abstract class BaseSpecification<T>
    {
        /// <summary>
        /// Expresión que representa los criterios de la consulta.
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Constructor que inicializa la especificación con una expresión de criterio.
        /// </summary>
        /// <param name="criteria">Expresión lambda que define los criterios de la consulta.</param>
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}