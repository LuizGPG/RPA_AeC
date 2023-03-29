using Microsoft.Extensions.DependencyInjection;
using Rpa_Aec.Repository.Entities;
using Rpa_Aec.Repository.Entities.Interfaces;
using Rpa_Aec.Services;
using Rpa_Aec.Services.Interfaces;

namespace Rpa_Aec.Infra
{
    public static class InjectionConfiguration
    {
        public static void AddServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IBuscaService, BuscaService>();
        }

        public static void AddRepositoriesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IBuscaRepository, BuscaRepository>();
        }
    }
}
