using FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado;
using FluxoDeCaixa.Domain.Models.Consolidado;
using FluxoDeCaixa.Domain.Services.Consolidado;
using FluxoDeCaixa.Infra.Repository.MongoDB.Repository;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.DTO.Response;
using FluxoDeCaixa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Consolidado
{
    public class ConsolidadoService : IConsolidadoService
    {
        private readonly IHistoricoTransacoesRepository _transacoesRepository;
        private readonly ConsolidadoCaixaService _consolidadoCaixaService;
        private readonly IConsolidadoMessageService _consolidadoMessageService;
        private readonly IConsolidadoRepository _consolidadoRepository;
        public ConsolidadoService(
            IHistoricoTransacoesRepository transacoesRepository,
            ConsolidadoCaixaService consolidadoCaixaService,
            IConsolidadoMessageService consolidadoMessageService,
            IConsolidadoRepository consolidadoRepository)
        {
            _transacoesRepository = transacoesRepository;
            _consolidadoCaixaService = consolidadoCaixaService;
            _consolidadoMessageService = consolidadoMessageService;
            _consolidadoRepository = consolidadoRepository;
        }



        public async Task<CaixaConsolidado> MontarCaixaConsolidado(MensagemConsolidadoRequestDTO request)
        {
            var historicoTransacoes = await _transacoesRepository.GetHistoricoTransacoes(request.CaixaId, request.DataInicial, request.DataFinal);

            if (historicoTransacoes.Any())
            {
                var primeiroHistorico = historicoTransacoes.First();
                var result = new CaixaConsolidado()
                {
                    MessageId = request.MessageId,
                    CaixaId = primeiroHistorico.CaixaId,
                    NomeCaixa = primeiroHistorico.NomeCaixa,
                    ValorConsolidado = _consolidadoCaixaService.ValorCaixaConsolidado(historicoTransacoes),
                    DataConsolidado = DateTime.Now,
                    DataRefInicial = request.DataInicial,
                    DataRefFinal = request.DataFinal,
                    Transacoes = new List<CaixaTransacoes>()

                };

                foreach (var item in historicoTransacoes)
                {
                    result.Transacoes.Add(new CaixaTransacoes()
                    {
                        Descricao = item.Descricao,
                        Valor = item.Valor,
                        DataCadastro = item.DataCadastro,
                        TipoLancamento = item.TipoLancamentoId
                    });
                }

                return result;
            }

            return null;
        }

        public void EnviarMensagemConsolidado(MensagemConsolidadoRequestDTO request)
        {
            try
            {
                _consolidadoMessageService.Send(request);
            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao enviar mensagem para o RabbitMQ - {e.Message}");
            }
        }

        public async Task GravarCaixaConsolidado(CaixaConsolidado caixaConsolidado)
        {
            try
            {
                await _consolidadoRepository.SalvarConsolidado(caixaConsolidado);
            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao gravar caixa consolidado - {e.Message}");
            }
        }

        public async Task<CaixaConsolidado> BuscarCaixaConsolidado(BuscarCaixaConsolidadoRequestDTO request)
        {
            try
            {
                var result = await _consolidadoRepository.BuscarCaixaConsolidado(request.MessageId, request.CaixaId);
                return result;
            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao buscar caixa consolidado - {e.Message}");
            }
        }
    }
}
