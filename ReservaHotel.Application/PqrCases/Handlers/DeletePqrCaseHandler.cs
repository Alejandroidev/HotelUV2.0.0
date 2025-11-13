using MediatR;
using ReservaHotel.Application.PqrCases.Commands;
using ReservaHotel.Application.PqrCases.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.PqrCases.Handlers
{
    public class DeletePqrCaseHandler : IRequestHandler<DeletePqrCaseCommand, CustomWebResponse>
    {
        private readonly IRepository<PqrCase> _repo;

        public DeletePqrCaseHandler(IRepository<PqrCase> repo)
        {
            _repo = repo;
        }

        public async Task<CustomWebResponse> Handle(DeletePqrCaseCommand request, CancellationToken ct)
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

            await _repo.DeleteAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = request.Id
            };
        }
    }
}