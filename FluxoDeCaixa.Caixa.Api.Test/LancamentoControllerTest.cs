
using AutoMapper;
using FluxoDeCaixa.Api.Facade.Interface;
using FluxoDeCaixa.Caixa.Api.Controllers;
using FluxoDeCaixa.Caixa.Api.Test.Factories;
using FluxoDeCaixa.Caixa.Api.Test.SetupIoC;
using FluxoDeCaixa.Domain.Enum;
using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Domain.Services.Caixa;
using FluxoDeCaixa.Infra.Infrastructure.Models;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.Lancamentos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;


namespace FluxoDeCaixa.Caixa.Api.Test
{
    public class LancamentoControllerTest
    {
        private ServiceProvider _serviceProvider;
        private LancamentosController _controller;

        public LancamentoControllerTest()
        {
            _serviceProvider = CaixaMockSetup.MockIoCProvider();
        }
        [Fact]
        public async void Post()
        {
            var request = new TransacoesRequestDTO()
            {
                CaixaId = new Guid("5c4a3177-785e-44c0-b21b-fc54ddb64976"),
                Descricao = "Credito",
                TipoLancamento = TipoLancamentoEnum.Credito,
                Valor = 10
            };

            var caixa = CaixaRepositoryFactory.GetCaixa();
            var transacao = TransacoesRepositoryFactory.Salvar(new Transacoes()
            {
                Id = Guid.NewGuid()
            });
            var buscarTransacoes = TransacoesRepositoryFactory.BuscarTransacoes(caixa.Id);

            var transacaoRepositoryMock = new Mock<ITransacoesRepository>();
            transacaoRepositoryMock.Setup(x => x.Salvar(new Transacoes()
            {
                Id = Guid.NewGuid()
            })).Returns(Task.Run(() => { return transacao; }));
            transacaoRepositoryMock.Setup(x => x.BuscarTransacoes(request.CaixaId)).Returns(Task.Run(() => { return buscarTransacoes; }));  

            var caixaRepositoryMock = new Mock<ICaixaRepository>();
            caixaRepositoryMock.Setup(x => x.GetCaixa()).Returns(Task.Run(() => { return caixa; }));
            caixaRepositoryMock.Setup(x => x.Salvar(caixa)).Returns(Task.CompletedTask);

            var saldoCaixaService = new SaldoCaixaService(caixaRepositoryMock.Object,transacaoRepositoryMock.Object);


            var consolidadoFacadeFacotry = ConsolidadoFacadeFactory.GravarHistoricoTransacao(null);
            var conslidadoFacadeMock = new Mock<IConsolidadoFacade>();
            conslidadoFacadeMock.Setup(x => x.GravarHistoricoTransacao(null)).Returns(Task.Run(() => { return consolidadoFacadeFacotry; }));

            var autoMapper = _serviceProvider.GetService<IMapper>();

            var lancamentoSerive = new LancamentoService(
                transacaoRepositoryMock.Object,
                saldoCaixaService,
                autoMapper,
                conslidadoFacadeMock.Object,
                caixaRepositoryMock.Object);


            _controller = new LancamentosController(lancamentoSerive);

            var result = await _controller.Post(request);
            var resultType = result as OkObjectResult;
            var retorno = resultType.Value as BaseResponse;

            Assert.NotNull(resultType);
            Assert.IsType<BaseResponse>(retorno);
            Assert.True(retorno.IsSuccess);
            Assert.False(!retorno.IsSuccess);
        }
    }
}
