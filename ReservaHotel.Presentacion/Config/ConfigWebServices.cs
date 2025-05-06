using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Services;

namespace ReservaHotel.Presentacion.Config;

public static class ConfigWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        #region scopes configurations
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IClientService, ClientService>();

        #endregion

        return services;
    }
}