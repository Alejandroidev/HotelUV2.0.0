using AutoMapper;
using MediatR;
using ReservaHotel.Application.Employees.Queries;
using ReservaHotel.Application.Employees.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Employees.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<Employee> _repo;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IReadRepository<Employee> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(GetEmployeeByIdQuery request, CancellationToken ct)
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

            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.EmployeeDto>(entity)
            };
        }
    }
}