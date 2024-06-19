using FluxoDeCaixa.Caixa.Api.Controllers;
using FluxoDeCaixa.Caixa.Api.Test.SetupIoC;
using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Infra.Infrastructure.Models;
using FluxoDeCaixa.Infra.Repository.Mysql.Context;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Caixa.Api.Test
{
    public class CaixaControllerTest
    {
        private CaixaController _controller;
        private ServiceProvider _serviceProvider;
        public CaixaControllerTest()
        {
            _serviceProvider = CaixaMockSetup.MockIoCProvider();
            _controller = new CaixaController(_serviceProvider.GetService<ICaixaService>());
        }

        [Fact]
        public async void GetAsync()
        {
            var result = await _controller.GetAsync();
            var resultType = result as OkObjectResult;
            var retorno = resultType.Value as BaseResponse;

            Assert.NotNull(resultType);
            Assert.IsType<BaseResponse>(retorno);
            Assert.True(retorno.IsSuccess);
            Assert.False(!retorno.IsSuccess);
        }

        [Fact]
        public async void GetSaldo()
        {
            var context = _serviceProvider.GetService<CaixaContext>();
            var result = await _controller.GetSaldo(context.Caixas.First().Id);
            var resultType = result as OkObjectResult;
            var retorno = resultType.Value as BaseResponse;

            Assert.NotNull(resultType);
            Assert.IsType<BaseResponse>(retorno);
            Assert.True(retorno.IsSuccess);
            Assert.False(!retorno.IsSuccess);
        }

    }
}
