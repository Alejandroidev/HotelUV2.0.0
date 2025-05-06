using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace ReservaHotel.Infrastructure.Persistence
{
    public class ReservaHotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
    {
        public HotelDbContext CreateDbContext(string[] args)
        {
            // Cambiar la ruta base al directorio del proyecto web
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../ReservaHotel.Web");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // Ruta al proyecto que contiene appsettings.json
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            return new HotelDbContext(optionsBuilder.Options);
        }
    }
}