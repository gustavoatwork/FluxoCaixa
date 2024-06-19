using FluxoDeCaixa.Domain.Enum;
using FluxoDeCaixa.Domain.Models.Consolidado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Services.Consolidado
{
    public class ConsolidadoCaixaService
    {

        public  decimal ValorCaixaConsolidado(List<HistoricoTransacoes> transacoes)
        {
            try
            {
                decimal credito = 0;
                decimal debito = 0;

                foreach (var item in transacoes)
                {
                    if (item.TipoLancamentoId == TipoLancamentoEnum.Credito)
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

                throw new Exception($"Erro ao calcular saldo consolidado");
            }
        }
    }
}
