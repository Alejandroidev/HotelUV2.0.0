using It270.MedicalManagement.Billing.Infrastructure.Data;
using It270.MedicalManagement.Billing.Presentation.WebApi.Config;
using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure.Persistence;
using ReservaHotel.Infrastructure.Seeding;
using ReservaHotel.Presentacion.Config;

namespace ReservaHotel.Presentacion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'HotelUColombiaContext' not found.")));

            builder.Services.AddCoreServices(builder.Configuration);
            builder.Services.AddWebServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;

                // Sedding database
                Console.WriteLine("Seeding Database...");

                try
                {
                    var generalContext = scopedProvider.GetRequiredService<HotelDbContext>();
                    await HotelDbContextSeed.SeedAsync(generalContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.StackTrace} ERROR CONCECCION");
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