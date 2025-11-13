using AutoMapper;
using MediatR;
using ReservaHotel.Application.Employees.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Employees.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CustomWebResponse>
    {
        private readonly IRepository<Employee> _repo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IRepository<Employee> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Employee>(request.Employee);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.EmployeeDto>(entity)
            };
        }
    }
}