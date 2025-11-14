using MediatR;
using ReservaHotel.Application.Common.Dtos;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.PqrCases.Commands
{
    /// <summary>
    /// Command to create a new PQR case.
    /// </summary>
    /// <param name="PqrCase">PQR case DTO payload.</param>
    public record CreatePqrCaseCommand(PqrCaseDto PqrCase) : IRequest<CustomWebResponse>;
}