using FluxoDeCaixa.Domain.Interfaces.Repository.Caixa;
using FluxoDeCaixa.Domain.Models.Caixa;
using FluxoDeCaixa.Domain.Models.Lancamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Caixa.Api.Test.Factories
{
    public class TransacoesRepositoryFactory
    {

        public static List<Transacoes> BuscarTransacoes(Guid caixaId)
        {
            var result = new List<Transacoes>();
            var caixas = CaixaRepositoryFactory.GetCaixa();
            result.Add(new Transacoes()
            {
                Id = Guid.NewGuid(),
                CaixaId = caixas.Id,
                Caixas = caixas,
                DataCadastro = DateTime.Now,
                Descricao = "Credito 1",
                TipoLancamentoId = 1,
                Valor = 145

            });
            result.Add(new Transacoes()
            {
                Id = Guid.NewGuid(),
                CaixaId = caixas.Id,
                Caixas = caixas,
                DataCadastro = DateTime.Now,
                Descricao = "Debito 1",
                TipoLancamentoId = 2,
                Valor = 33

            });

            return result;
        }

        public static Transacoes Salvar(Transacoes transacao)
        {
            var caixas = CaixaRepositoryFactory.GetCaixa();
            return new Transacoes()
            {
                Id = Guid.NewGuid(),
                CaixaId = caixas.Id,
                Caixas = caixas,
                DataCadastro = DateTime.Now,
                Descricao = "Credito 1",
                TipoLancamentoId = 1,
                Valor = transacao.Valor

            };
        }
    }
}
