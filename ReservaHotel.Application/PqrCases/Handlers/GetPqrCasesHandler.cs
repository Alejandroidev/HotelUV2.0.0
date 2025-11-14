using AutoMapper;
using MediatR;
using ReservaHotel.Application.PqrCases.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.PqrCases.Handlers
{
    /// <summary>
    /// Handles requests to list all PQR cases.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetPqrCasesQuery(), ct);
    /// </remarks>
    public class GetPqrCasesHandler : IRequestHandler<GetPqrCasesQuery, CustomWebResponse>
    {
        private readonly IReadRepository<PqrCase> _repo;
        private readonly IMapper _mapper;

        public GetPqrCasesHandler(IReadRepository<PqrCase> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetPqrCasesQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.PqrCaseDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}