using Microsoft.Extensions.DependencyInjection;
using ApiImob.Domain.Interfaces;
using ApiImob.Domain.DomainServices;
using ApiImob.Infra.Services;
using ApiImob.App.AppServices;
using Microsoft.Extensions.Configuration;
using ApiImob.Infra.Connections;
using Microsoft.EntityFrameworkCore;

namespace ApiImob.IOC
{
    public static class DependencyInjectionConfig
    {
        private static IServiceCollection _services;

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            _services = services;

            RegistrarApp();
            RegistrarDomain();
            RegistrarInfra();

            return services;

        }

        public static IServiceCollection AddServices (this IServiceCollection services, IConfiguration configuration) 
        {
            return services;
        }

        private static void RegistrarApp()
        {
            _services.AddScoped<IImoveisAppService, ImoveisAppService>();
            _services.AddScoped<ICidadesAppService, CidadesAppService>();
        }
        private static void RegistrarDomain()
        {
            _services.AddScoped<IImoveisDomainService, ImoveisDomainService>();
            _services.AddScoped<ICidadesDomainService, CidadesDomainService>();
        }
        private static void RegistrarInfra()
        {
            _services.AddScoped<IImoveisInfraService, ImoveisInfraService>();
            _services.AddScoped<ICidadesInfraService, CidadesInfraService>();
        }
    }
}
