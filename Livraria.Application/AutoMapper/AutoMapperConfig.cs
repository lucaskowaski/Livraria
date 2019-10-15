using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.Application.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelToViewModelMappingProfile), typeof(ViewModelToModelMappingProfile));
        }
    }
}
