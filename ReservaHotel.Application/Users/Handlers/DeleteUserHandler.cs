using MediatR;
using ReservaHotel.Application.Users.Commands;
using ReservaHotel.Application.Users.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.Users.Handlers
{
    /// <summary>
    /// Handles user deletion requests.
    /// Example:
    /// try { var res = await _mediator.Send(new DeleteUserCommand(id), ct); } catch { /* log */ }
    /// </summary>
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, CustomWebResponse>
    {
        private readonly IRepository<User> _repo;

        public DeleteUserHandler(IRepository<User> repo)
        {
            _repo = repo;
        }

        /// <inheritdoc />
        public async Task<CustomWebResponse> Handle(DeleteUserCommand request, CancellationToken ct)
        {
            try
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

                await _repo.DeleteAsync(entity, ct);
                return new CustomWebResponse
                {
                    ResponseBody = request.Id
                };
            }
            catch
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred while deleting the user."
                };
            }
        }
    }
}