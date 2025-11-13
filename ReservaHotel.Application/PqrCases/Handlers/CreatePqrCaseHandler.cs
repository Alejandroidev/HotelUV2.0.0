using AutoMapper;
using MediatR;
using ReservaHotel.Application.PqrCases.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.PqrCases.Handlers
{
    public class CreatePqrCaseHandler : IRequestHandler<CreatePqrCaseCommand, CustomWebResponse>
    {
        private readonly IRepository<PqrCase> _repo;
        private readonly IMapper _mapper;

        public CreatePqrCaseHandler(IRepository<PqrCase> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreatePqrCaseCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<PqrCase>(request.PqrCase);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.PqrCaseDto>(entity)
            };
        }
    }
}