using FluxoDeCaixa.Api.Facade.Consolidado;
using FluxoDeCaixa.Api.Facade.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade.IoC
{
    public class FacadeInjector
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IFacadeService, FacadeService>();
            service.AddScoped<IConsolidadoFacade, ConsolidadoFacade>();
        }
    }
}
