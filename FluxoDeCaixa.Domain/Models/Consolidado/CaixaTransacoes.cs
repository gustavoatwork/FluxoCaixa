using FluxoDeCaixa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Models.Consolidado
{
    public class CaixaTransacoes
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
