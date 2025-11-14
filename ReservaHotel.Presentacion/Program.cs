using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure;
using ReservaHotel.Infrastructure.Data;
using ReservaHotel.Presentacion.Config;
using Microsoft.OpenApi.Models;
using It270.MedicalManagement.Billing.Presentation.WebApi.Config;
using System.Reflection;

namespace ReservaHotel.Presentacion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            builder.Services.AddCoreServices(builder.Configuration);
            builder.Services.AddWebServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ReservaHotel API",
                    Version = "v1",
                    Description = "API REST de gestión de reservas de hotel"
                });

                // Include XML comments from all projects
                var basePath = AppContext.BaseDirectory;
                var xmlFiles = new[]
                {
                    "ReservaHotel.Presentacion.xml",
                    "ReservaHotel.Application.xml",
                    "ReservaHotel.Domain.xml",
                    "ReservaHotel.Infrastructure.xml"
                };
                foreach (var xml in xmlFiles)
                {
                    var xmlPath = Path.Combine(basePath, xml);
                    if (File.Exists(xmlPath))
                    {
                        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                    }
                }
            });

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
                await db.Database.EnsureCreatedAsync();
                try { await db.Database.MigrateAsync(); } catch { }
                await HotelDbContextSeed.SeedAsync(db);
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservaHotel API v1");
                c.DisplayRequestDuration();
            });

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/", () => Results.Redirect("/swagger"));

            app.Run();
        }
    }
}