using FluxoDeCaixa.Domain.Services.Consolidado;
using FluxoDeCaixa.Services.Consolidado;
using FluxoDeCaixa.Services.Interfaces;
using FluxoDeCaixa.Services.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.IoC.Modules.Consolidado
{
    public class ConsolidadoServiceModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<ConsolidadoCaixaService>();
            service.AddScoped<IHistoricoTransacoesService, HistoricoTransacoesService>();
            service.AddScoped<IConsolidadoService, ConsolidadoService>();
            service.AddScoped<IConsolidadoMessageService, ConsolidadoMessageService>();
        }
    }
}
