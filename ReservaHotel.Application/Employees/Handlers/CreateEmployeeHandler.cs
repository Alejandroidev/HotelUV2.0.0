using AutoMapper;
using MediatR;
using ReservaHotel.Application.Employees.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Employees.Handlers
{
    /// <summary>
    /// Handles employee creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateEmployeeCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CustomWebResponse>
    {
        private readonly IRepository<Employee> _repo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IRepository<Employee> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Employee>(request.Employee);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.EmployeeDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the employee."
                };
            }
        }
    }
}