using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelUColombia.Data;

/// <summary>
/// Dependencias, Configuraci�n de conexi�n a BD
/// </summary>
public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        // Ensure the Npgsql.EntityFrameworkCore.PostgreSQL package is installed
        services.AddDbContext<HotelUColombiaContext>(c => c.UseNpgsql(configuration.GetConnectionString("HotelUColombiaContext")));
    }
}
