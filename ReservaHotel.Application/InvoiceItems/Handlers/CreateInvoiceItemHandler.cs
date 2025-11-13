using AutoMapper;
using MediatR;
using ReservaHotel.Application.InvoiceItems.Commands;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Domain.Entities;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Application.InvoiceItems.Handlers
{
    public class CreateInvoiceItemHandler : IRequestHandler<CreateInvoiceItemCommand, CustomWebResponse>
    {
        private readonly IRepository<InvoiceItem> _repo;
        private readonly IMapper _mapper;

        public CreateInvoiceItemHandler(IRepository<InvoiceItem> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomWebResponse> Handle(CreateInvoiceItemCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<InvoiceItem>(request.InvoiceItem);
            await _repo.AddAsync(entity, ct);
            return new CustomWebResponse
            {
                ResponseBody = _mapper.Map<Application.Common.Dtos.InvoiceItemDto>(entity)
            };
        }
    }
}