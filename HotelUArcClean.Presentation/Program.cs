using HotelUColombia.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelUArcClean.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<HotelUColombiaContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("HotelUColombiaContext")));

            // Agregar controladores con vistas
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Crear o migrar la base de datos automáticamente
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HotelUColombiaContext>();
                dbContext.Database.Migrate(); // Aplica migraciones pendientes
                // dbContext.Database.EnsureCreated(); // Alternativa: crea la base de datos si no existe
            }

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}