using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GestionFastFood.Models;
using GestionFastFood.Services;

namespace GestionFastFood
{
    public class Program
    {
        public static void Main(string[] args)
            
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Registrar DBContext

            builder.Services.AddDbContext<RestauranteDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDB")));

            builder.Services.AddScoped<EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Acceso/User");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                {
                    app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acceso}/{action=Register}/{id?}");

                    /*Ruta específica para el controlador 'Reserva' y su acción 'Index'
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller= reservas/{action=ListaReserva}/{id?}";
                      
                });*/
                });

            app.Run();

        }
        
    }
}