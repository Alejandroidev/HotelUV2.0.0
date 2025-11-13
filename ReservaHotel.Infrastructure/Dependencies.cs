using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaHotel.Infrastructure.Data;
using System;

namespace ReservaHotel.Infrastructure;

public static class Dependencies
{
    private static readonly string? _connectionString = Environment.GetEnvironmentVariable("SYSTEM_CS_MAIN");

    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        var cs = _connectionString ?? configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("No connection string configured");
        services.AddDbContext<HotelDbContext>(c => c.UseNpgsql(cs));
    }
}