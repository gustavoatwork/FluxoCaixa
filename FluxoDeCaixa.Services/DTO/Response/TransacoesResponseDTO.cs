using FluxoDeCaixa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.DTO.Response
{
    public class TransacoesResponseDTO
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
