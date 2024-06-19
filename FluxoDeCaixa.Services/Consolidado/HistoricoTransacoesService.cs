using AutoMapper;
using FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado;
using FluxoDeCaixa.Domain.Models.Consolidado;
using FluxoDeCaixa.Domain.Models.Lancamentos;
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
    public class HistoricoTransacoesService : IHistoricoTransacoesService
    {
        private readonly IHistoricoTransacoesRepository _historicoTransacoesRepository;
        private readonly IMapper _mapper;

        public HistoricoTransacoesService(
            IHistoricoTransacoesRepository historicoTransacoesRepository,
            IMapper mapper)
        {
            _historicoTransacoesRepository = historicoTransacoesRepository;
            _mapper = mapper;
        }



        public async Task GravarHistoricoTransacoes(HistoricoTransacaoRequestDTO transacao)
        {
            var newHistorico = _mapper.Map<HistoricoTransacoes>(transacao);
            newHistorico.DataCadastro = DateTime.Today;
            newHistorico.DataHoraCadastro = transacao.DataCadastro.ToString();
            await _historicoTransacoesRepository.SalvarHistoricoTransacoes(newHistorico);
        }
    }
}
