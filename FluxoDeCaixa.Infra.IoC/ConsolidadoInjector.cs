
using FluxoDeCaixa.Infra.Infrastructure.AutoMapper;
using FluxoDeCaixa.Infra.IoC.Modules.Consolidado;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.IoC
{
    public class ConsolidadoInjector
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {

            service.AddSingleton(configuration);
            AutoMapperConfig.Register(service);
            ConsolidadoDataBaseModule.Register(service);
            ConsolidadoServiceModule.Register(service);

        }
    }
}
