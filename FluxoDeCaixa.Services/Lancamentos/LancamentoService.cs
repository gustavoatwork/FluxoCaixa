using AutoMapper;
using FluxoDeCaixa.Api.Facade.DTO;
using FluxoDeCaixa.Api.Facade.Interface;
using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Consolidado;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using FluxoDeCaixa.Domain.Services.Caixa;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.DTO.Response;
using FluxoDeCaixa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Lancamentos
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ITransacoesRepository _transacoesRepository;
        private readonly ICaixaRepository _caixaRepository;
        private readonly IConsolidadoFacade _consolidadoFacadeService;
        private readonly SaldoCaixaService _saldoCaixaService;
        private IMapper _mapper;
        public LancamentoService(
            ITransacoesRepository transacoesRepository,
            SaldoCaixaService saldoCaixaService,
            IMapper mapper,
            IConsolidadoFacade consolidadoService,
            ICaixaRepository caixaRepository)
        {
            _transacoesRepository = transacoesRepository;
            _saldoCaixaService = saldoCaixaService;
            _mapper = mapper;
            _consolidadoFacadeService = consolidadoService;
            _caixaRepository = caixaRepository;
        }

        public async Task<LancamentoResponseDTO> GetLancamentos(Guid caixaId)
        {
            try
            {
                var transacoes = await _transacoesRepository.BuscarTransacoes(caixaId);

                if (!transacoes.Any()) throw new Exception("Transaçoes não encontradas para o caixa ");

                var result = new LancamentoResponseDTO
                {
                    Caixa = transacoes.First().Caixas,
                    Transacoes = _mapper.Map<List<TransacoesResponseDTO>>(transacoes)
                };

                return result;

            }
            catch (Exception)
            {

                throw new Exception($"Erro ao buscar lancamentos do caixa {caixaId}");
            }
        }

        public async Task GravarTransacao(TransacoesRequestDTO transacao)
        {
            try
            {
                var caixa = await _caixaRepository.GetCaixa();
                if (caixa.Id != transacao.CaixaId) throw new Exception("Caixa não encontrado");

                if (transacao.Valor <= 0) throw new Exception("O valor deve ser maior que zero");

                var novaTransacao = new Transacoes()
                {
                    CaixaId = transacao.CaixaId,
                    Descricao = transacao.Descricao,
                    TipoLancamentoId = (int)transacao.TipoLancamento,
                    Valor = transacao.Valor,
                    DataCadastro = DateTime.Now
                };

                var result = await _transacoesRepository.Salvar(novaTransacao);
                await _saldoCaixaService.AtualizarSaldoCaixa(transacao.CaixaId);
                var request = _mapper.Map<TransacoesDTO>(result);
                await _consolidadoFacadeService.GravarHistoricoTransacao(request);


            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao gravar transação no caixa {transacao.CaixaId} - {e.Message}");
            }
        }
    }
}
