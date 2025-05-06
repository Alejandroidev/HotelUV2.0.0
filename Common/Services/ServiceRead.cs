
using System.Net;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Specifications.General;
using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using Serilog;

namespace ReservaHotel.Application.Services.General;

/// <summary>
/// General service for only read functions
/// </summary>
/// <typeparam name="E">Entity type</typeparam>
/// <typeparam name="DTO">DTO class type</typeparam>
/// <typeparam name="ET">Entity identifier type</typeparam>
/// <typeparam name="GS">General Specification type</typeparam>
public abstract class ServiceRead<E, DTO, ET, GS> : IServiceRead<DTO, ET>
    where DTO : class, IDto
    where ET : notnull
    where E : class, IAggregateRoot
    where GS : GeneralSpecification<ET, E>
{
    /// <summary>
    /// Generic entity repository
    /// </summary>
    protected readonly IRepository<E> _entityRepository;

    /// <summary>
    /// General mapper
    /// </summary>
    protected readonly IMapper _mapper;


    /// <summary>
    /// Initialize service
    /// </summary>
    public ServiceRead(IRepository<E> entityRepository,
        IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Check if element exists
    /// </summary>
    /// <param name="id">Element identifier</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Process result</returns>
    public virtual async Task<bool> Exists(ET id, CancellationToken ct = default)
    {
        var specification = (GS)Activator.CreateInstance(typeof(GS), new object[] { id });
        return await _entityRepository.AnyAsync(specification, ct);
    }

    /// <summary>
    /// Get element
    /// </summary>
    /// <param name="id">Element identifier</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Process result</returns>
    public virtual async Task<CustomWebResponse> Get(ET id, CancellationToken ct = default)
    {
        var specification = (GS)Activator.CreateInstance(typeof(GS), new object[] { id });
        var dataEntity = await _entityRepository.FirstOrDefaultAsync(specification, ct);

        if (dataEntity != null)
        {
            var dataDto = _mapper.Map<DTO>(dataEntity);
            return new CustomWebResponse()
            {
                ResponseBody = dataDto
            };
        }
        else
        {
            return new CustomWebResponse(true)
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Not found",
            };
        }
    }

    /// <summary>
    /// Get all elements
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Process result</returns>
    public virtual async Task<CustomWebResponse> GetAll(CancellationToken ct = default)
    {
        var dataListEntity = await _entityRepository.ListAsync(ct);
        var dataListDto = _mapper.Map<List<DTO>>(dataListEntity);

        return new CustomWebResponse()
        {
            ResponseBody = dataListDto
        };
    }

    /// <summary>
    /// Get elements list (paginated)
    /// </summary>
    /// <param name="skip">Page</param>
    /// <param name="take">Page size</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Process result</returns>
    public virtual async Task<CustomWebResponse> GetList(int skip, int take, CancellationToken ct = default)
    {
        var specification = (GS)Activator.CreateInstance(typeof(GS), new object[] { skip, take });
        var dataListEntity = await _entityRepository.ListAsync(specification, ct);
        var dataListDto = _mapper.Map<List<DTO>>(dataListEntity);

        return new CustomWebResponse()
        {
            ResponseBody = dataListDto
        };
    }

    /// <summary>
    /// Get elements list (DevExtreme)
    /// </summary>
    /// <param name="loadOptions">DevExtreme load options</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Process result</returns>
    public async Task<CustomWebResponse> GetList(DataSourceLoadOptions loadOptions, CancellationToken ct = default)
    {
        // Handle data with DevExtreme
        loadOptions.RequireTotalCount = true;

        if (loadOptions.Skip < 0)
            loadOptions.Skip = 0;
        if (loadOptions.Take <= 0)
            loadOptions.Take = 10;

        var dataListEntity = await _entityRepository.ListAsync(ct);
        var loadResult = DataSourceLoader.Load(dataListEntity, loadOptions);
        loadResult.data = _mapper.Map<List<DTO>>(loadResult.data);

        return new CustomWebResponse()
        {
            ResponseBody = loadResult
        };
    }
}