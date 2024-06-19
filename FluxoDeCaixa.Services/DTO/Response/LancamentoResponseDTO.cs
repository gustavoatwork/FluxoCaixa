using FluxoDeCaixa.Domain.Models.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.DTO.Response
{
    public class LancamentoResponseDTO
    {
        public Caixas Caixa { get; set; }
        public List<TransacoesResponseDTO> Transacoes { get; set; }
    }
}
