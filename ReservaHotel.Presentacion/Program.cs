using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure.Persistence;
using ReservaHotel.Infrastructure.Seeding;

namespace ReservaHotel.Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar la conexión a la base de datos
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ReservaHotelDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Agregar Razor Pages
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Sembrar datos iniciales
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ReservaHotelDbContext>();
                ReservaHotelDbContextSeed.Seed(context);
            }

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapRazorPages();
            app.Run();
        }
    }
}