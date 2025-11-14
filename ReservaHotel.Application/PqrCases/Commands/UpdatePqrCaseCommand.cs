using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;
using System;

namespace ReservaHotel.Application.PqrCases.Commands
{
    /// <summary>
    /// Command to update an existing PQR case.
    /// </summary>
    /// <param name="Id">PQR case identifier.</param>
    /// <param name="PqrCase">Updated PQR case DTO.</param>
    public record UpdatePqrCaseCommand(Guid Id, PqrCaseDto PqrCase) : IRequest<CustomWebResponse>;
}