using FluxoDeCaixa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.DTO.Request
{
    public class TransacoesRequestDTO
    {
        public Guid CaixaId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
    }
}
