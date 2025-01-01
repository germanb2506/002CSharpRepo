
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Configuración de la cadena de conexión para PostgreSQL
            string connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

            // Configura el DbContext para usar PostgreSQL con la cadena de conexión
            builder.Services.AddDbContext<Context>(options =>
              options.UseNpgsql(connectionString));
            // Add services to the container.
            // Llamar a la extensión para registrar servicios 
            builder.Services.AddServices();
            builder.Services.AddControllers();
            // Configurar Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiPersonalizada", Version = "v1" });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiV1");
                    c.RoutePrefix = string.Empty; // Para que Swagger UI esté en la raíz
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
