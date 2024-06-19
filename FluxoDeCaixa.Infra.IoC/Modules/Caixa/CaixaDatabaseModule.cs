using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado;
using FluxoDeCaixa.Infra.Repository.MongoDB.Repository;
using FluxoDeCaixa.Infra.Repository.Mysql.Context;
using FluxoDeCaixa.Infra.Repository.Mysql.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infra.IoC.Modules.Caixa
{
    public static class CaixaDatabaseModule
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("FluxoCaixa");
            service.AddDbContext<CaixaContext>(op => op.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            service.AddScoped<ICaixaRepository, CaixaRepository>();
            service.AddScoped<ITransacoesRepository, TransacoesRepository>();
        }
    }
}
