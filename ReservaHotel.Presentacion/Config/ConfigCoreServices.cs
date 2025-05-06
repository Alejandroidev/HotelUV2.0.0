using Common.Helper;
using Common.Interfaces;

using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Infrastructure;
using ReservaHotel.Presentacion.Controllers.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaHotel.Application.Config;


namespace It270.MedicalManagement.Billing.Presentation.WebApi.Config;

public static class ConfigCoreServices
{
    /// <summary>
    /// Add core services
    /// </summary>
    /// <param name="services">Service descriptors collection</param>
    /// <param name="configuration">System configuration</param>
    /// <returns>Service descriptors collection with custom services</returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configure custom configuration class
        services.Configure<CustomConfig>(configuration.GetSection("Project"));

        services.AddHealthChecks();
        services.AddHttpContextAccessor();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        services.AddSingleton<IWebTools, WebTools>();

        return services;
    }
}