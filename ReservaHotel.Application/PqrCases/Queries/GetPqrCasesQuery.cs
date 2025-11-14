using MediatR;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.PqrCases.Queries
{
    /// <summary>
    /// Query to list all PQR cases.
    /// </summary>
    public record GetPqrCasesQuery() : IRequest<CustomWebResponse>;
}