using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.PqrCases.Queries
{
    /// <summary>
    /// Query to retrieve a PQR case by identifier.
    /// </summary>
    /// <param name="Id">PQR case identifier.</param>
    public record GetPqrCaseByIdQuery(Guid Id) : IRequest<CustomWebResponse>;
}