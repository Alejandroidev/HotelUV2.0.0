using AutoMapper;
using MediatR;
using ReservaHotel.Application.PqrCases.Commands;
using ReservaHotel.Application.PqrCases.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.PqrCases.Handlers
{
    public class UpdatePqrCaseHandler : IRequestHandler<UpdatePqrCaseCommand, CustomWebResponse>
    {
        private readonly IRepository<PqrCase> _repo;
        private readonly IMapper _mapper;

        public UpdatePqrCaseHandler(IRepository<PqrCase> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(UpdatePqrCaseCommand request, CancellationToken ct)
        {
            var spec = new PqrCaseByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "PqrCase not found"
                };
            }

            _mapper.Map(request.PqrCase, entity);
            await _repo.UpdateAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.PqrCaseDto>(entity)
            };
        }
    }
}