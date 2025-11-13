using It270.MedicalManagement.Billing.Presentation.WebApi.Config;
using Microsoft.EntityFrameworkCore;
using ReservaHotel.Infrastructure;
using ReservaHotel.Infrastructure.Data;
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
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            builder.Services.AddCoreServices(builder.Configuration);
            builder.Services.AddWebServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddRazorPages();

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

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseDeveloperExceptionPage();
            }

            app.MapControllers();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapRazorPages();
            app.Run();
        }
    }
}