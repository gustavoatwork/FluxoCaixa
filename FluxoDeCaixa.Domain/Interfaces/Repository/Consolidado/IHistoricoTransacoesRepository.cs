using FluxoDeCaixa.Domain.Models.Consolidado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado
{
    public interface IHistoricoTransacoesRepository
    {
        Task<List<HistoricoTransacoes>> GetHistoricoTransacoes(Guid CaixaId, DateTime dataInicial, DateTime dataFinal);
        Task SalvarHistoricoTransacoes(HistoricoTransacoes historicoTransacoes);
    }
}
