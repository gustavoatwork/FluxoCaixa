using FluxoDeCaixa.Infra.IoC.Modules;
using FluxoDeCaixa.Infra.IoC;
using FluxoDeCaixa.Infra.Repository.Mysql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Infra.Repository.Mysql.Repository;
using FluxoDeCaixa.Api.Facade.IoC;
using FluxoDeCaixa.Infra.Infrastructure.AutoMapper;
using FluxoDeCaixa.Infra.IoC.Modules.Caixa;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Moq;
using FluxoDeCaixa.Api.Facade.Interface;
using FluxoDeCaixa.Services.Interfaces;
using FluxoDeCaixa.Services.Caixa;

namespace FluxoDeCaixa.Caixa.Api.Test.SetupIoC
{
    public static class CaixaMockSetup
    {

        public static ServiceProvider MockIoCProvider()
        {
            var service = new ServiceCollection();

            service.AddScoped<ICaixaRepository, CaixaRepository>();
            service.AddScoped<ITransacoesRepository, TransacoesRepository>();

            var config = Configuration.GetConfiguration();
            service.AddSingleton(config);

            JWTAuthentication.ConfigureAuthentication(service, config);
            CaixaInjector.Register(service, config);
            var serviceProvider = service.BuildServiceProvider();

            return serviceProvider;

        }

    }
}
