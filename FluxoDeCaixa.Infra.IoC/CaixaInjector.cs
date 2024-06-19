
using FluxoDeCaixa.Api.Facade.IoC;
using FluxoDeCaixa.Infra.Infrastructure.AutoMapper;
using FluxoDeCaixa.Infra.IoC.Modules.Caixa;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa.Infra.IoC
{
    public class CaixaInjector
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {

            service.AddSingleton(configuration);
            AutoMapperConfig.Register(service);
            CaixaDatabaseModule.Register(service,configuration);
            CaixaServiceModule.Register(service);
            FacadeInjector.Register(service);


        }


    }
}
