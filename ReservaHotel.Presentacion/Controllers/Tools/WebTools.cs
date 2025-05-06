using Common.Entitys.Presentacion;
using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Domain.Entities.Base;

namespace ReservaHotel.Presentacion.Controllers.Tools;

[ApiController]
[Route("[controller]")]
public class WebTools : WebToolsBase
{
    public WebTools(IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor)
    { }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override string GetBaseUrl()
    {
        return base.GetBaseUrl();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override IActionResult CustomResponse(CustomWebResponse response)
    {
        return base.CustomResponse(response);
    }
}