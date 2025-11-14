using MediatR;
using ReservaHotel.Application.Employees.Commands;
using ReservaHotel.Application.Employees.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Employees.Handlers
{
    /// <summary>
    /// Handles employee deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteEmployeeCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, CustomWebResponse>
    {
        private readonly IRepository<Employee> _repo;

        public DeleteEmployeeHandler(IRepository<Employee> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteEmployeeCommand request, CancellationToken ct)
        {
            try
            {
                var spec = new EmployeeByIdSpec(request.Id);
                var entity = await _repo.FirstOrDefaultAsync(spec, ct);
                if (entity == null)
                {
                    return new CustomWebResponse(true)
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Employee not found"
                    };
                }

                await _repo.DeleteAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = request.Id
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while deleting the employee."
                };
            }
        }
    }
}