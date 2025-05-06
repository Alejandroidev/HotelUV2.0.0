using It270.MedicalManagement.Billing.Infrastructure.Data;
using It270.MedicalManagement.Billing.Presentation.WebApi.Config;
using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure.Persistence;
using ReservaHotel.Infrastructure.Seeding;
using ReservaHotel.Presentacion.Config;
using Serilog;

namespace ReservaHotel.Presentacion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Verifica que la cadena de conexión no esté vacía
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Connection string: {connectionString}");

            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(connectionString));

            Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services.AddCoreServices(builder.Configuration);
            builder.Services.AddWebServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Sembrar datos iniciales
            using (var scope = app.Services.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;

                // Sedding database
                Log.Information("Seeding Database...");
                try
                {
                    var generalContext = scopedProvider.GetRequiredService<HotelDbContext>();
                    await HotelDbContextSeed.SeedAsync(generalContext);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred seeding the DB.");
                }
            }

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseDeveloperExceptionPage();
            }

            app.MapControllers();
            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapRazorPages();
            app.Run();
        }
    }
}