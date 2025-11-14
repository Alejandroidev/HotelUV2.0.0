using AutoMapper;
using MediatR;
using ReservaHotel.Application.Users.Queries;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.Users.Handlers
{
    /// <summary>
    /// Handles requests to list all users.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetUsersQuery(), ct);
    /// </remarks>
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, CustomWebResponse>
    {
        private readonly IReadRepository<User> _repo;
        private readonly IMapper _mapper;

        public GetUsersHandler(IReadRepository<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetUsersQuery request, CancellationToken ct)
        {
            var list = await _repo.ListAsync(ct);
            var dto = _mapper.Map<List<Application.Common.Dtos.UserDto>>(list);
            return new CustomWebResponse
            {
                ResponseBody = dto
            };
        }
    }
}