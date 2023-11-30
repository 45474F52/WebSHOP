using Microsoft.EntityFrameworkCore;
using WebShopAPI.Models.Data;

namespace WebShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
                       
            string connectionString = builder.Configuration.GetConnectionString("WebShop")
                ?? throw new Exception("Нет строки подлючения к БД");

            builder.Services.AddDbContext<ShopDataContext>(options
                => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddControllers();

            WebApplication app = builder.Build();

            app.UseCors(builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

            app.UseStaticFiles();
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}