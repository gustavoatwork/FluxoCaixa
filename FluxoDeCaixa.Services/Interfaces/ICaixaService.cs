using FluxoDeCaixa.Domain.Models.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.Interfaces
{
    public interface ICaixaService
    {
        Task<Caixas> GetCaixa();
        Task<decimal> GetSaldoCaixa(Guid IdCaixa);
    }
}
