using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado;
using FluxoDeCaixa.Infra.Repository.MongoDB.Repository;
using FluxoDeCaixa.Infra.Repository.Mysql.Context;
using FluxoDeCaixa.Infra.Repository.Mysql.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.IoC.Modules.Consolidado
{
    public static class ConsolidadoDataBaseModule
    {
        public static void Register(IServiceCollection service)
        {

            service.AddScoped<IHistoricoTransacoesRepository, HistoricoTransacoesRepository>();
            service.AddScoped<IConsolidadoRepository, ConsolidadoRepository>();
        }
    }
}
