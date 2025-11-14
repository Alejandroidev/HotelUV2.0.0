using MediatR;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.PqrCases.Commands
{
    /// <summary>
    /// Command to delete a PQR case by identifier.
    /// </summary>
    /// <param name="Id">PQR case identifier.</param>
    public record DeletePqrCaseCommand(Guid Id) : IRequest<CustomWebResponse>;
}