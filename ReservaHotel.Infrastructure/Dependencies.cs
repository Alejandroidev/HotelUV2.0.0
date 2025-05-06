using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaHotel.Infrastructure.Persistence;
using System;

namespace It270.MedicalManagement.Billing.Infrastructure.Data;

public static class Dependencies
{
    private static readonly string _connectionString = Environment.GetEnvironmentVariable("SYSTEM_CS_MAIN");

    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<HotelDbContext>(c =>
            c.UseNpgsql(_connectionString)
        );
    }
}