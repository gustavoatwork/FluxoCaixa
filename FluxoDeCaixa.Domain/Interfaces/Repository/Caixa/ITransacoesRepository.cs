using FluxoDeCaixa.Domain.Models.Lancamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Interfaces.Repository.Caixa
{
    public interface ITransacoesRepository
    {
        Task<Transacoes> Salvar(Transacoes transacao);
        Task<List<Transacoes>> BuscarTransacoes(Guid caixaId);
    }
}
