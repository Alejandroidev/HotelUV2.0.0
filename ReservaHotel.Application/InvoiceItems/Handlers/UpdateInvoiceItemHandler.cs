using AutoMapper;
using MediatR;
using ReservaHotel.Application.InvoiceItems.Commands;
using ReservaHotel.Application.InvoiceItems.Specifications;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;
using System.Net;

namespace ReservaHotel.Application.InvoiceItems.Handlers
{
    public class UpdateInvoiceItemHandler : IRequestHandler<UpdateInvoiceItemCommand, CustomWebResponse>
    {
        private readonly IRepository<InvoiceItem> _repo;
        private readonly IMapper _mapper;

        public UpdateInvoiceItemHandler(IRepository<InvoiceItem> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(UpdateInvoiceItemCommand request, CancellationToken ct)
        {
            var spec = new InvoiceItemByIdSpec(request.Id);
            var entity = await _repo.FirstOrDefaultAsync(spec, ct);
            if (entity == null)
            {
                return new CustomWebResponse(true)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "InvoiceItem not found"
                };
            }

            _mapper.Map(request.InvoiceItem, entity);
            await _repo.UpdateAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.InvoiceItemDto>(entity)
            };
        }
    }
}