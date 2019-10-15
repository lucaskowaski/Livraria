using Livraria.Application.Interfaces;
using Livraria.Application.Services;
using Livraria.Domain.Interfaces;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.infra.CrossCutting.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Aplication
            services.AddScoped<ILivroService, LivroService>();

            // Infra - Data
            services.AddScoped<LivrariaContext>();
            services.AddScoped<ILivroRepository, LivroRepository>();

        }
    }
}
