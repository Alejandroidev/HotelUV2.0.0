using ReservaHotel.Application.Interfaces;
using ReservaHotel.Application.Interfaces.General;
using ReservaHotel.Application.Services.Hotel;


namespace ReservaHotel.Presentacion.Config;

public static class ConfigWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        #region scopes configurations
        services.AddScoped<IBookingService, BookingService>();

        #endregion

        return services;
    }
}