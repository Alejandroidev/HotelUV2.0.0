using HotelUColombia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class HotelUColombiaContextFactory : IDesignTimeDbContextFactory<HotelUColombiaContext>
{
    public HotelUColombiaContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<HotelUColombiaContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("HotelUColombiaContext"));

        return new HotelUColombiaContext(optionsBuilder.Options);
    }
}