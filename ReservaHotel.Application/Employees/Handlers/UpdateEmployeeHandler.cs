using AutoMapper;
using MediatR;
using ReservaHotel.Application.Employees.Commands;
using ReservaHotel.Application.Employees.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Employees.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, CustomWebResponse>
    {
        private readonly IRepository<Employee> _repo;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IRepository<Employee> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(UpdateEmployeeCommand request, CancellationToken ct)
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

            _mapper.Map(request.Employee, entity);
            await _repo.UpdateAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.EmployeeDto>(entity)
            };
        }
    }
}