using FluxoDeCaixa.Domain.Models.Consolidado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Interfaces.Repository.Consolidado
{
    public interface IConsolidadoRepository
    {
        Task<CaixaConsolidado> BuscarCaixaConsolidado(Guid MessageId, Guid CaixaId);
        Task SalvarConsolidado(CaixaConsolidado caixaConsolidado);
    }
}
