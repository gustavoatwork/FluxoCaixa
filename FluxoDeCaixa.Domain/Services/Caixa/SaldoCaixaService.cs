using FluxoDeCaixa.Domain.Enum;
using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Services.Caixa
{
    public class SaldoCaixaService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly ITransacoesRepository _transacoesRepository;
        public SaldoCaixaService(ICaixaRepository caixaRepository, ITransacoesRepository transacoesRepository)
        {
            _caixaRepository = caixaRepository;
            _transacoesRepository = transacoesRepository;
        }

        public async Task AtualizarSaldoCaixa(Guid caixaId)
        {
            try
            {
                var caixa = await _caixaRepository.GetCaixa();

                if (caixa == null) throw new Exception("Caixa não encontrado");

                var saldoAtualizado = await CalcularSaldoAtualizado(caixaId);

                caixa.Saldo = saldoAtualizado;
                caixa.DataAtualizacao = DateTime.Now;
                await _caixaRepository.Salvar(caixa);

            }
            catch (Exception)
            {

                throw new Exception($"Erro ao atualizar saldo do caixa {caixaId}");
            }
        }

        private async Task<decimal> CalcularSaldoAtualizado(Guid caixaId)
        {
            try
            {
                var transacoes = await _transacoesRepository.BuscarTransacoes(caixaId);
                decimal credito = 0;
                decimal debito = 0;

                foreach (var item in transacoes)
                {
                    if (item.TipoLancamentoId == (int)TipoLancamentoEnum.Credito)
                    {
                        credito += item.Valor;
                    }
                    else
                    {
                        debito += item.Valor;
                    }
                }

                return (credito - debito);

            }
            catch (Exception)
            {

                throw new Exception("Erro ao calcular saldo atualizado");
            }
        }
    }
}
