using FluxoDeCaixa.Domain.Models.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Interfaces.Repository.Caixa
{
    public interface ICaixaRepository
    {
        Task<Caixas> GetCaixa();
        Task<decimal> SaldoCaixa(Guid caixaId);
        Task Salvar(Caixas caixa);
    }
}
