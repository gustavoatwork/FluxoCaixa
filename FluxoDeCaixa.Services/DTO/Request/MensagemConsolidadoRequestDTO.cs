using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Services.DTO.Request
{
    public class MensagemConsolidadoRequestDTO
    {
        public Guid MessageId { get; set; }
        public Guid CaixaId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
