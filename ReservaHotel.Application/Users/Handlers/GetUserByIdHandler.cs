using AutoMapper;
using MediatR;
using ReservaHotel.Application.Users.Queries;
using ReservaHotel.Application.Users.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Users.Handlers
{
    /// <summary>
    /// Handles requests to retrieve a user by identifier.
    /// </summary>
    /// <remarks>
    /// Example:
    /// var result = await _mediator.Send(new GetUserByIdQuery(id), ct);
    /// </remarks>
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, CustomWebResponse>
    {
        private readonly IReadRepository<User> _repo;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IReadRepository<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(GetUserByIdQuery request, CancellationToken ct)
        {
            var spec = new UserByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "User not found"
                };
            }
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.UserDto>(entity)
            };
        }
    }
}