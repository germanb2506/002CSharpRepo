using Businnes.Contratos;
using Businnes.Logica;

namespace WebApi
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Agrega las dependencias relacionadas con la seguridad.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        /// <returns>La colección de servicios actualizada.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICrud, Crud>();
            return services;
        }
    }
}
