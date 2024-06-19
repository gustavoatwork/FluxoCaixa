using FluxoDeCaixa.Domain.Models.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.DTO.Request
{
    public class HistoricoTransacaoRequestDTO
    {
        public Guid Id { get; set; }
        public Guid CaixaId { get; set; }
        public Caixas Caixas { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int TipoLancamentoId { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
