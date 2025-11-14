using AutoMapper;
using MediatR;
using ReservaHotel.Application.Users.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Users.Handlers
{
    /// <summary>
    /// Handles user creation requests.
    /// Example:
    /// try { var res = await _mediator.Send(new CreateUserCommand(dto), ct); } catch { /* log */ }
    /// </summary>
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CustomWebResponse>
    {
        private readonly IRepository<User> _repo;
        private readonly IMapper _mapper;

        public CreateUserHandler(IRepository<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(CreateUserCommand request, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<User>(request.User);
                await _repo.AddAsync(entity, ct);
                return new CustomWebResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    ResponseBody = _mapper.Map<Application.Common.Dtos.UserDto>(entity)
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while creating the user."
                };
            }
        }
    }
}